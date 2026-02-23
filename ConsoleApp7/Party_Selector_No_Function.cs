// See https://aka.ms/new-console-template for more information



// 함수 없이
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

// 값을 받을 배열 생성
// 유저 개별로 받은 정보를 다뤄야 하기 때문에
// 한 인덱스에 여러 정보들을 한번에 저장하기 위해 가변배열로 지정
// 최종 멤버의 정보를 받을 빈 배열도 지정
// 배열을 안쓰면 요소 하나하나 전부 다 따로 변수에 재할당 하면서 for문을 실행해줘야함
// 전체 값을 재설정하는게 가능은 하지만 데이터가 늘면 늘수록 메모리 소모가 극심해짐.


string[][] member = new string[5][];
string[][] partyMember = new string[5][];

// 정보를 string으로 받음
// readline 이나 다른 곳으로부터 정보를 받았다고 가정함
partyMember[0] = new string[] { "루시드", "250", "180", "true" };
partyMember[1] = new string[] { "윌", "89", "95", "false" };
partyMember[2] = new string[] { "데미안", "200", "210", "true" };
partyMember[3] = new string[] { "세렌", "175", "160", "true" };
partyMember[4] = new string[] { "칼로스", "310", "300", "false" };

//입장 조건 체크 변수
bool isLevel = false;
bool isScore = false;
bool isQuest = false;

// 최종 파티원 수 카운트
int count = 0;

Console.WriteLine("=== 던전: 검은 마법사의 성 ===");
Console.WriteLine();
Console.WriteLine("** 입장 조건 **");
Console.WriteLine(
    "1. 레벨 200 이상" +
    "\n2. 장비 점수 150 이상" +
    "\n3. 사전 퀘스트 완료");
Console.WriteLine();
Console.WriteLine("==== 지원 목록 ====");

// 신청받은 파티원 수에 따라 for문 작동
for (int i = 0; i < partyMember.Length; i++)
{
    // 한 멤버의 조건 판단이 끝날 때 마다 초기화
    isLevel = false;
    isScore = false;
    isQuest = false;

    // 파티원 개별정보를 조사
    for (int j = 0; j < partyMember[i].Length; j++)
    {
        // 정보 출력
        Console.Write($"{partyMember[i][j]}\t");

        // 받은 데이터 양식이 고정이기 때문에 동일한 위치에 해당 정보가 들어있음
        // 인덱스로 분류해서 조건 판단
        // 형변환을 전부 해주면서 해야한다는 불편함이 있음.
        switch (j)
        {
            case 1:
                if (int.Parse(partyMember[i][j]) >= 200) { isLevel = true; } //레벨
                break;
            case 2:
                if (int.Parse(partyMember[i][j]) >= 150) { isScore = true; } //장비점수
                break;
            case 3:
                if (partyMember[i][j] == "true") { isQuest = true; } // 퀘스트 클리어 여부
                break;
        }
    }

    // 개별정보 조사가 끝났을 때 조건 만족 시 최종멤버 배열에 넣어준 후 카운트
    if (isLevel && isQuest && isScore)
    {

        member[count] = partyMember[i];
        count++;
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("==== 최종 파티 ====");

// 최종멤버 정보를 받은 배열에서 이름만 추출해서 출력
for (int i = 0; i < count; i++)
{
    Console.WriteLine(member[i][0]);
}

Console.WriteLine($"총 인원 수: {count}");
