using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ReadWriteMemory;
using Offsets;

namespace FunkyMonkey {
    public class MemoryReader {
        public bool isSuccess = false;
        public Vector3 playerPos = new Vector3(0f, 0f, 0f);
        public Vector2 playerAim = new Vector2(0f, 0f);
        public string nearestPlayerName;

        private ProcessMemory memory;
        private uint gameModule;
        private uint engineModule;
        private uint localPlayer;
        private uint glowObject;
        private uint clientState;

        private float shortestEnemyDistance = -1;

        public MemoryReader() {
            memory = new ProcessMemory("csgo");
            if (!memory.CheckProcess()) {
                MessageBox.Show("The proccess was not found!", "Error");
            } else {
                isSuccess = true;
            }
        }

        public void Start() {
            if (!isSuccess) return;
            memory.StartProcess();

            gameModule = (uint)memory.DllImageAddress("client_panorama.dll");
            engineModule = (uint)memory.DllImageAddress("engine.dll");

            do {
                localPlayer = memory.ReadUInt((int)gameModule + signatures.dwLocalPlayer);
            } while (localPlayer == 0);
            glowObject = memory.ReadUInt((int)gameModule + signatures.dwGlowObjectManager);
            clientState = memory.ReadUInt((int)engineModule + signatures.dwClientState);
        }

        public void Update() {
            EssentialUpdates();
            uint nearestEnemy = 0;
            for (short i = 0; i < 32; i++) {
                uint entity = memory.ReadUInt((int)gameModule + signatures.dwEntityList + i * 0x10);
                if (entity == 0) continue;

                if (Options.RADAR) Radar(entity);
                if (Options.GLOW) Glow(entity);

                if (!isSameTeam(entity)) {
                    uint e_boneMatrix = memory.ReadUInt((int)entity + netvars.m_dwBoneMatrix);
                    Vector3 enemyHead = new Vector3(
                        memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x0C),
                        memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x1C),
                        memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x2C)
                    );
                    float distanceToPlayer = Vector3.Distance(enemyHead, playerPos);
                    if (shortestEnemyDistance == -1 || nearestEnemy == 0) {
                        nearestEnemy = entity;
                        shortestEnemyDistance = distanceToPlayer;
                    }
                    if (distanceToPlayer < shortestEnemyDistance) {
                        int entityHp = memory.ReadInt((int)nearestEnemy + netvars.m_iHealth);
                        byte entityLife = memory.ReadByte((int)nearestEnemy + netvars.m_lifeState);
                        if (entityHp > 0 && entityLife == 1) {
                            shortestEnemyDistance = distanceToPlayer;
                            nearestEnemy = entity;
                            nearestPlayerName = memory.ReadStringAscii((int)nearestEnemy + netvars.m_szCustomName, 30);
                        } else {
                            shortestEnemyDistance = -1;
                            nearestEnemy = 0;
                            continue;
                        }
                    }
                }
            }

            if (Options.AIMBOT && nearestEnemy != 0) Aim(nearestEnemy);
        }

        private void EssentialUpdates() {
            playerPos.x = memory.ReadFloat((int)localPlayer + netvars.m_vecOrigin);
            playerPos.y = memory.ReadFloat((int)localPlayer + netvars.m_vecOrigin + 0x4);
            playerPos.z = memory.ReadFloat((int)localPlayer + netvars.m_vecOrigin + 0x8);

            playerAim.x = memory.ReadFloat((int)clientState + signatures.dwClientState_ViewAngles);
            playerAim.y = memory.ReadFloat((int)clientState + signatures.dwClientState_ViewAngles + 0x4);
        }

        private void Radar(uint entity) {
            memory.WriteByte((int)entity + (int)netvars.m_bSpotted, 1);
        }

        private void Glow(uint entity) {
            int glowIndex = memory.ReadInt((int)entity + netvars.m_iGlowIndex);

            if (!isSameTeam(entity)) {
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x4, Options.GLOW_VAL.ENEMY.R);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x8, Options.GLOW_VAL.ENEMY.G);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0xC, Options.GLOW_VAL.ENEMY.B);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x10, Options.GLOW_VAL.ENEMY.A);
            } else {
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x4, Options.GLOW_VAL.FRIENDLY.R);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x8, Options.GLOW_VAL.FRIENDLY.G);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0xC, Options.GLOW_VAL.FRIENDLY.B);
                memory.WriteFloat((int)glowObject + glowIndex * 0x38 + 0x10, Options.GLOW_VAL.FRIENDLY.A);
            }

            memory.WriteByte((int)glowObject + glowIndex * 0x38 + 0x24, 1);
            memory.WriteByte((int)glowObject + glowIndex * 0x38 + 0x25, 0);
        }

        private bool isSameTeam(uint entity) {
            int entityTeam = memory.ReadInt((int)entity + netvars.m_iTeamNum);
            int clientTeam = memory.ReadInt((int)localPlayer + netvars.m_iTeamNum);

            return entityTeam == clientTeam;
        }

        private Vector3 GetAimAngle(Vector3 player, Vector3 target) {
            Vector3 delta = new Vector3(
                player.x - target.x,
                player.y - target.y,
                player.z - target.z + Options.PLAYER_HEAD_OFFSET
            );
            double hyp = Math.Sqrt(Math.Pow(delta.x, 2f) + Math.Pow(delta.y, 2f));

            Vector3 angles = new Vector3(
                (float)Math.Asin(delta.z / hyp) * 57.295779513082f,
                (float)Math.Atan(delta.y / delta.x) * 57.295779513082f,
                0f
            );

            if (delta.x >= 0) angles.y += 180f;

            return angles;
        }

        private void Aim(uint entity) {
            uint e_boneMatrix = memory.ReadUInt((int)entity + netvars.m_dwBoneMatrix);
            Vector3 enemyHead = new Vector3(
                memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x0C),
                memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x1C),
                memory.ReadFloat((int)e_boneMatrix + 0x30 * 8 + 0x2C)
            );
            Vector3 angles = GetAimAngle(playerPos, enemyHead);

            if (!Double.IsNaN(angles.x) && !Double.IsNaN(angles.y)) {
                memory.WriteFloat((int)clientState + signatures.dwClientState_ViewAngles, angles.x);
                memory.WriteFloat((int)clientState + signatures.dwClientState_ViewAngles + 0x4, angles.y);
            }
        }
    }
}
