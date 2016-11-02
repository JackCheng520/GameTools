using Game.Core.DataStruct;
using Game.Core.Obj;
using Game.Core.Obj.Fms;
using Game.Core.Util;
using Game.Model.Define;
using Game.Model.PO;
using Game.Model.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Util
{
    public static  class CharactorUtil
    {

        private static SKillCompare _skillCompare = null;

        public static bool isJumpStatic(Charactor charactor) {

            if (charactor.fms.currentStatic == CharactorStaticType.JUMP_CUSION ||
               charactor.fms.currentStatic == CharactorStaticType.JUMP_DOWN ||
               charactor.fms.currentStatic == CharactorStaticType.JUMP_SPRINT ||
               charactor.fms.currentStatic == CharactorStaticType.JUMP_UP){
                return true;
            }

            return false;
        }


        public static Vector3 getSkillRange(SkillPo skillPo) {
            string[] skillRangeArr = skillPo.skillRange.Split('|');

            Vector3 result = Vector3.zero;
            result.x = Convert.ToSingle(skillRangeArr[1]);
            result.y = Convert.ToSingle(skillRangeArr[2]);
            result.z = Convert.ToSingle(skillRangeArr[3]);

            return result;
        }


        /// <summary>
        /// 是否再技能范围内；
        /// </summary>
        public static bool isInSkillView(Charactor me, SkillPo skillPo, Vector3 pos)
        {
            float[] skillRangeArr = skillPo.arrSkillRange;

            int type = Convert.ToInt32(skillRangeArr[0]);


            switch (type)
            {
                case 0: //扇形；

                    float halfAngle   = skillRangeArr[1];
                    float radius      = skillRangeArr[2];
                    float orgDistance = skillRangeArr[3];

                    Sector sector = new Sector();
                    sector.angle = halfAngle;
                    sector.r = radius;
                    sector.org = me.transform.position;
                    sector.offset = me.transform.forward * orgDistance;

                    return MathC.isInSector(sector, pos);

                case 1: //矩形；rectangle

                    float halfWidth   =  skillRangeArr[1];
                    float lenght      =  skillRangeArr[2];
                    float orgDis      =  skillRangeArr[3];

                    Rectangle rectangle = new Rectangle();
                    rectangle.transform = me.transform;
                    rectangle.width = halfWidth;
                    rectangle.length = lenght;
                    rectangle.offset = me.transform.forward * orgDis;

                    return MathC.isInRect(rectangle, pos);
            }

            return false;
        }


      
        public static Charactor findNearestCharactor(Charactor me)
        {
            Charactor monster = findNearestMonster(me);
            //Tag
            Charactor player = null;//findNearestPlayer(me);
            if (monster == null && player == null) return null;

            if (monster != null && player != null)
            {
                double distMonster = Vector3.Distance(me.transform.position, monster.transform.position);
                double distPlayer = Vector3.Distance(me.transform.position, player.transform.position);
                return (distMonster > distPlayer) ? player : monster;
            }
            return (monster == null) ? player : monster;
        }



        /// <summary>
        /// 获取视野内离我最近的Monster；
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Monster findNearestMonster(Charactor me)
        {

            List<Monster> monsters = GameApp.sceneController.monsters;
            Monster monster, resultMonster = null;

            for (int i = 0, len = monsters.Count; i < len; i++)
            {
                monster = monsters[i];

                if (me.charactorVo.id == monster.charactorVo.id) continue;
                if (monster.fms.currentStatic == CharactorStaticType.DIE) continue; 
                if (!GameObjectUtil.isInView(me.view, monster.transform.position)) continue;
                if (resultMonster == null) { resultMonster = monster; continue; }


                double dist = Vector3.Distance(me.transform.position, monster.transform.position);
                double dist2 = Vector3.Distance(me.transform.position, resultMonster.transform.position);

                if (dist < dist2) resultMonster = monster;
            }

            return resultMonster;
        }


        /// <summary>
        /// 获取视野内离我最近的Player；
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Charactor findNearestPlayer(Charactor me)
        {
            List<Player> players = GameApp.sceneController.players;
            Player player, resultPlayer = null;

            for (int i = 0, len = players.Count; i < len; i++)
            {
                player = players[i];

                if (me.charactorVo.id == player.charactorVo.id) continue;
                if (player.fms.currentStatic == CharactorStaticType.DIE) continue; 

                if (!GameObjectUtil.isInView(me.view, player.transform.position)) continue;
   

                if (resultPlayer == null) { resultPlayer = player; continue; }


                double dist = Vector3.Distance(me.transform.position, player.transform.position);
                double dist2 = Vector3.Distance(me.transform.position, resultPlayer.transform.position);

                if (dist < dist2) resultPlayer = player;
            }

 
            return resultPlayer;

        }


        //根据优先级选择技能，不包含CD中的；
        public static SkillPo selectSkill(Player player)
        {
            List<SkillPo> skillPos = new List<SkillPo>();
            //所有不处于CD状态的技能；
            for (int i = 0, len = player.skillPos.Count; i < len; i++)
            {
                bool isCd = GameApp.gameCDMgr.checkGameCD(i);
                if (isCd) continue;
                skillPos.Add(player.skillPos[i]);
            }

            //选择优先级最高的项；
            if (_skillCompare == null) {
                _skillCompare = new SKillCompare();
            }

            skillPos.Sort(_skillCompare);
            return skillPos[0];
        }

        //根据优先级选择技能，不包含CD中的；
        public static SkillPo selectSkill(Monster monster)
        {
            List<SkillPo> skillPos = new List<SkillPo>();
            //所有不处于CD状态的技能；
            for (int i = 0, len = monster.skillPos.Count; i < len; i++)
            {
                SkillPo skillPo = monster.skillPos[i];
                bool isCd = (skillPo.skillSeat > 0)?monster.charactorCd.isInCD(skillPo.id):false;
                if (isCd) continue;

                skillPos.Add(monster.skillPos[i]);
            }

            //选择优先级最高的项；
            if (_skillCompare == null)
            {
                _skillCompare = new SKillCompare();
            }

            skillPos.Sort(_skillCompare);
            return skillPos[0];

        }


        /// <summary>
        /// 获得PVP Players
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static List<Player> getPvpPlayers(Player me, List<Player> players)
        {

            int scenePkType = GameApp.curScenePo.pkType;

            //PVP 的判定；
            switch (scenePkType)
            {
                case SceneDefineType.PK_TYPE_SAFE: return null;
                case SceneDefineType.PK_TYPE_NEUTRALITY:
                    if (me.charactorVo.pkStatus == PKStateType.PK_PEACE) return null;
                    break;
                default: break;
            }

 
            List<Player> result = new List<Player>();

            Player player = null;
            for (int i = 0, len = players.Count; i < len; i++) {

                player = players[i];

                if (player.charactorVo.id == me.charactorVo.id) continue;
                if (player.charactorVo.teamId != 0 && player.charactorVo.teamId == me.charactorVo.teamId) continue;

                //红名状态忽略PK规则；
                if (me.charactorVo.pkValue > 0){
                    result.Add(player); continue;
                }

                //门派刺探暴露状态为1时，忽略规则；
                if (me.charactorVo.clanTaskSpyIsExposure == 1) {
                    result.Add(player); continue;
                }

                if (me.charactorVo.faction != 0 && player.charactorVo.faction == me.charactorVo.faction) continue;

                //帮会战；
                if (GameApp.activityProgressController.isInActivity(GameApp.activityProgressController.KEY_ACTIVITY_GUILD_WAR)) {
                    if (me.charactorVo.guildId == me.charactorVo.guildId) continue;
                }

          
                switch (scenePkType){

                    case SceneDefineType.PK_TYPE_NEUTRALITY:

                        if (player.charactorVo.pkStatus == PKStateType.PK_PEACE) continue;
                        if (me.charactorVo.pkStatus == PKStateType.PK_GANG && player.charactorVo.guildId == me.charactorVo.guildId) {
                           bool isEnemy =  me.isInPvpEnemys(me.charactorVo.id);
                           if (!isEnemy) continue;
                        }
                        
                        break;

                    case SceneDefineType.PK_TYPE_DANGER:

                        if (player.charactorVo.pkStatus == PKStateType.PK_PEACE && me.charactorVo.pkStatus == PKStateType.PK_PEACE) continue; 
          
                        if (me.charactorVo.pkStatus == PKStateType.PK_GANG && player.charactorVo.guildId == me.charactorVo.guildId)
                        {
                            bool isEnemy = me.isInPvpEnemys(me.charactorVo.id);
                            if (!isEnemy) continue;
                        }

                        break;

                    case  SceneDefineType.PK_TYPE_KILLZONE:

                        if (player.charactorVo.pkStatus == PKStateType.PK_PEACE && me.charactorVo.pkStatus == PKStateType.PK_PEACE) continue; 

                        if (me.charactorVo.pkStatus == PKStateType.PK_GANG && player.charactorVo.guildId == me.charactorVo.guildId) {
                            bool isEnemy = me.isInPvpEnemys(me.charactorVo.id);
                            if (!isEnemy) continue;
                        }

                        break;

                    case SceneDefineType.PK_TYPE_CHAOS:

                        if (player.charactorVo.pkStatus == PKStateType.PK_PEACE && me.charactorVo.pkStatus == PKStateType.PK_PEACE) continue; 

                        if (me.charactorVo.pkStatus == PKStateType.PK_GANG && player.charactorVo.guildId == me.charactorVo.guildId)
                        {
                            bool isEnemy = me.isInPvpEnemys(me.charactorVo.id);
                            if (!isEnemy) continue;
                        }
                        
                        break;
                    case SceneDefineType.PK_TYPE_CLAN:break;
                    default: break;
                }

                result.Add(player);
            }

            return result;
        }

        #region buffer相关；
        public static BufferVo getBufferVoById(CharactorVo charactorVo,int bufferId) {
            for (int i = 0, len = charactorVo.bufferVos.Count; i < len; i++) {
                if (charactorVo.bufferVos[i].id == bufferId) {
                    return charactorVo.bufferVos[i];
                }
            }

            return null;
        }
        #endregion


        public static Vector3 getRelivePoint() {


            //初始化主角坐标；
            Vector3 point = Vector3.zero;

            //传送门过来；
            if (GameApp.tansforPos != Vector3.zero)
            {
                point = GameApp.tansforPos;
                GameApp.tansforPos = Vector3.zero;
                return point;
            }

            //刚上线，服务器保存的坐标；
            if (GameApp.isFirst) {

                point = new Vector3(GameApp.dataCache.rolePo.x,GameApp.dataCache.rolePo.y,GameApp.dataCache.rolePo.z) * MMOSetting.INT_TO_FLOAT;

                if (point != Vector3.zero) return samplePosition(point);
                
            }

            switch(GameApp.curScenePo.pointType){
                case SceneDefineType.RELIVETYPE_COMMON:
                               point = StringUtil.getVector3ByString(GameApp.curScenePo.relivePoint,'|');    
                    break; 
                case SceneDefineType.RELIVETYPE_RANDOM:
                              Vector3[] positions = StringUtil.getVector3sByString(GameApp.curScenePo.relivePoint,',','|');
                              point = positions[UnityEngine.Random.Range(0, positions.Length - 1)];
                    break;
                case SceneDefineType.RELIVETYPE_FACTION:
                              Vector3[] arrPos = StringUtil.getVector3sByString(GameApp.curScenePo.relivePoint,',','|');
                               if( GameApp.dataCache.roleVo.faction == 0 || GameApp.dataCache.roleVo.faction == 1){
                                    point = arrPos[0];
                               }else{
                                    point = arrPos[1];
                               }
                    break;
                default:break;
            }

            point = point * MMOSetting.INT_TO_FLOAT;
            return    point;
        }

        private static Vector3 samplePosition(Vector3 point) {
            ////有效位置点；
            NavMeshHit hit;
            if (NavMesh.SamplePosition(point, out hit, 100, NavMesh.AllAreas))
            {
                point = hit.position;
            }

            return point;
        }


        public static Flag getFlagByFreshId(int freshId) {
            
            List<GameObj> gameObjs = GameApp.sceneController.gameObjs;
            for (int i = 0, len = gameObjs.Count; i < len; i++)
            {
                Flag flag = gameObjs[i] as Flag;
                if (flag == null) continue;

                if (flag.charactorVo.monsterFreshId == freshId)
                {
                    return flag;
                }

            }

            return null;
        }
 
 
        public static BufferVo getBufferVoByType(CharactorVo charactorVo, int bufferType) {
            BufferVo bufferVo = null;
            for (int i = 0, len = charactorVo.bufferVos.Count; i < len; i++)
            {
                bufferVo = charactorVo.bufferVos[i];

                if (bufferVo.bufferPo.arrBufferValue[0] == bufferType)
                {
                    return bufferVo;
                }
            }
            return bufferVo;
        }



        public class CharactorVoCompare : IComparer<CharactorVo>
        {
            int IComparer<CharactorVo>.Compare(CharactorVo c1, CharactorVo c2)
            {

                Vector3 heroPosition = GameApp.sceneController.hero.transform.position;
                float d1 = Vector3.Distance(heroPosition, c1.pos);
                float d2 = Vector3.Distance(heroPosition, c2.pos);

                if (d1 > d2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public class CharactorCompare : IComparer<Charactor>
        {

            int IComparer<Charactor>.Compare(Charactor c1, Charactor c2)
            {

                Vector3 heroPosition = GameApp.sceneController.hero.transform.position;
                float d1 = Vector3.Distance(heroPosition, c1.transform.position);
                float d2 = Vector3.Distance(heroPosition, c2.transform.position);


                if (d1 > d2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public class GameObjCompare : IComparer<GameObj> {
            int IComparer<GameObj>.Compare(GameObj c1, GameObj c2){

                Vector3 heroPosition = GameApp.sceneController.hero.transform.position;
                float d1 = Vector3.Distance(heroPosition, c1.transform.position);
                float d2 = Vector3.Distance(heroPosition, c2.transform.position);

                if (d1 > d2){
                    return 1;
                }else{
                    return -1;
                }
            }
        }



        public class SKillCompare : IComparer<SkillPo>
        {
            int IComparer<SkillPo>.Compare(SkillPo c1, SkillPo c2)
            {
                return (c1.skillPriority > c2.skillPriority) ? -1 : 1;
            }
        }
    }
}
