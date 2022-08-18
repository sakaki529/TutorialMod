using Microsoft.Xna.Framework;
using Terraria;

namespace TutorialMod.Projectiles
{
    /// <summary>
    /// 汎用性のある発射体のAIをメソッドとして簡単に実行できるようにしておくためのクラスです。
    /// 追尾や索敵など頻繁に使用するけど書くのが面倒、長くなるものなどを実行できるようにしておくと良いでしょう。
    /// 出来る人は拡張メソッドにしてもらっても問題ないと思います。
    /// </summary>
    public class TutorialProjAI
    {
        /// <summary>
        /// 索敵用メソッド。発射体に最も近いターゲット可能なNPCを取得することが出来ます。
        /// </summary>
        /// <param name="projectile"></param>
        /// <param name="maxDetectDistance">対象との最長距離</param>
        /// <param name="ignoreTiles">対象と発射体間の直線上に存在するタイルを無視するかどうか</param>
        /// <param name="minion">これがtrueの場合、ミニオン用にターゲットされた敵を優先で取得します</param>
        /// <returns>最も近いターゲット可能なnpc。発見できなかった場合はnullを返します。</returns>
        public static NPC FindClosestNPC(Projectile projectile, float maxDetectDistance, bool ignoreTiles = false, bool minion = false)
        {
            NPC closestNPC = null;
            if (minion)
            {
                NPC ownerMinionAttackTargetNPC = projectile.OwnerMinionAttackTargetNPC;
                if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy() && Vector2.Distance(ownerMinionAttackTargetNPC.Center, projectile.Center) < maxDetectDistance && (ignoreTiles || Collision.CanHitLine(projectile.Center, 1, 1, ownerMinionAttackTargetNPC.Center, 1, 1)))
                    return ownerMinionAttackTargetNPC;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if (target.CanBeChasedBy() && (ignoreTiles || Collision.CanHit(projectile.Center, 1, 1, target.Center, 1, 1)))
                {
                    float targetDistance = projectile.Center.Distance(target.Center);
                    if (targetDistance < maxDetectDistance)
                    {
                        maxDetectDistance = targetDistance;
                        closestNPC = target;
                    }
                }
            }
            return closestNPC;
        }
        /// <summary>
        /// NPCを追尾する発射体用AI
        /// </summary>
        /// <param name="projectile">挙動を行う発射体</param>
        /// <param name="maxDetectDistance">対象との最長距離</param>
        /// <param name="speed">速度</param>
        /// <param name="inertia">慣性: 大きければ大きいほど緩やかに動きます</param>
        /// <param name="ignoreTiles">対象と発射体間の直線上に存在するタイルを無視するかどうか</param>
        public static void HomingToNPC(Projectile projectile, float maxDetectDistance, float speed, float inertia, bool ignoreTiles = false)
        {
            NPC target = FindClosestNPC(projectile, maxDetectDistance, ignoreTiles);//FindClosestNPCを使用し、索敵を行います
            if (target == null)//発見できなかった場合は実行しません
                return;
            Vector2 targetVec = target.Center - projectile.Center;//発射体の中心から敵の中心に向かうベクトル
            float dist = targetVec.Length();
            dist = speed / dist;
            targetVec *= dist;
            projectile.velocity = (projectile.velocity * inertia + targetVec) / (inertia + 1f);
        }
    }
}
