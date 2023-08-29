using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    // ------- Song --------
    // 스킬 목록 구현
    public class SkillList
    {
        // 알파 스트라이크
        Skill alphaStrike = new Skill("알파 스트라이크", "공격력 * 2로 하나의 적을 공격합니다.", 10);
        // 더블 스트라이크
        Skill doubleStrike = new Skill("더블 스트라이크", "공격력 * 1.5로 2명의 적을 랜덤으로 공격합니다.", 15);
    }
}
