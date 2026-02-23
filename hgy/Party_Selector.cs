// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

// 함수 이용

Console.WriteLine("=== 던전: 검은 마법사의 성 ===");
Console.WriteLine();
Console.WriteLine("** 입장 조건 **");
Console.WriteLine(
    "1. 레벨 200 이상" +
    "\n2. 장비 점수 150 이상" +
    "\n3. 사전 퀘스트 완료");
Console.WriteLine();


// 이름만 넘겨주면 되기 때문에 StringBuilder 이용
// 모든 정보를 출력하고 싶으면 위의 방식대로 하면 됌
StringBuilder sb = new StringBuilder();


// 입장조건 확인 변수
bool isEntry = false;

// 파티원 수 체크
int count = 0;
    
// 멤버 정보 체크하는 함수
void MemberCheck(string name, int level = 1, int score = 1, bool isQuest = false )
{
    // 체크 조건 초기화
    isEntry = false;

    // 정보 출력
    Console.WriteLine($"{name}");
        
    // 받은 정보로 유저 상태 체크 및 정보 출력
    ConditionCheck(level, score, isQuest);
    count += MemberCount(name);
        


}

// 입장 조건 체크. MemberCheck()함수 안에서 실행
void ConditionCheck(int level = 1, int score = 1, bool isQuest = false)
{

    // 받은 매개변수를 토대로 입장 조건 플래그 설정



    // 플래그에 따라 정보 및 스크립트 출력
    // 얻은 bool 값을 입장 확인 함수로 넘겨줌
    // 여기서 바로 체크를 해도 되지만 기능 분리를 해서 가독성을 높임
    isEntry = EntryCondition(LevelCheck(level), ScoreCheck(score), QuestCheck(isQuest));


    Console.WriteLine(isEntry ? "입장 가능" : "입장 불가능");
    Console.WriteLine("-----------------------");
}

// 레벨 체크
bool LevelCheck(int level)
{
    bool isLevel = level >= 200;
    Console.WriteLine(isLevel ? $"레벨: {level}" : $"레벨: {level} !! 레벨이 부족합니다(입장레벨 200이상) !!");

    return isLevel;

}

// 장비 점수 체크
bool ScoreCheck(int score)
{
    bool isScore = score >= 150;
    Console.WriteLine(isScore ? $"장비점수: {score}" : $"장비 점수: {score} !! 장비 점수가 부족합니다(장비점수 150점 이상 !!)" );

    return isScore;

}

// 퀘스트 체크
bool QuestCheck(bool quest)
{

    Console.WriteLine(quest ? $"선행퀘스트 완료" : "!! 선행퀘스트를 완료해주세요 !!");

    return quest;

}


// 입장 확인 및 플래그 설정
// 기능 분리를 통해 향후 추가되는 조건 대비나 가독성을 높이기 위함. << #1
bool EntryCondition(bool islevel, bool isScore, bool isQuest)
{

    return isScore && islevel && isQuest;

}

// 입장 가능한 인원인지 계산하는 함수
// 이름도 같이받아서 명단에 추가함
int MemberCount(string name)
{
    // 파티원 명단에 추가
    if (isEntry)
    {
        sb.AppendLine(name);

    }

    // 멤버 카운트
    return isEntry ? 1 : 0;

}


// 최종 파티원 목록 출력
void LastPartyMember()
{
    Console.WriteLine("==== 최종 파티 ====");
    Console.Write(sb); // 줄바꿈으로 분리되기 때문에 write 사용
    Console.WriteLine($"총 인원 수: {count}");
}


// 위처럼 배열로 받는게 편하지만 함수에서 특정 요소들을 편하게 활용하기 위해서
// 각 타입별로 분리해서 작성. 실제로는 입력값이 어떻게 들어올 지는 미지수라 어느게 낫다 하기 뭐함. <<#2
// 다만 매개변수를 활용하면 새로운 정보칸이 생겼을 때 정보 정렬이 편하지만
// 배열로 하면 수정이 불가하기에 새로 싹 리뉴얼 해야하는 단점이 명확함.
Console.WriteLine("==== 지원 목록 ====");
MemberCheck("루시드", 250, 180, true);
Console.WriteLine();
    
MemberCheck("윌", 89, 95, false);
Console.WriteLine();
    
MemberCheck("데미안", 200, 210, true);
Console.WriteLine();
    
MemberCheck("세렌", 175, 160, true);
Console.WriteLine();
    
MemberCheck("칼로스", 310, 300, false);
Console.WriteLine();

LastPartyMember();



