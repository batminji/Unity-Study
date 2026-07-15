using UnityEngine;

public class Example : MonoBehaviour
// MonoBehaviour를 상속받은 클래스는 Unity의 게임 오브젝트에 부착될 수 있는 스크립트임
{
    private void Awake()                // 게임 오브젝트가 생성될 때 한 번만 호출되는 함수, 초기화 작업에 사용됨
    {
        Debug.Log("Awake called");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()                        // 게임 오브젝트가 활성화될 때 한 번만 호출되는 함수, 초기화 작업에 사용됨
    {
        Debug.Log("Start called");
    }

    // Update is called once per frame
    void Update()                       // 게임 로직을 업데이트할 때 사용되는 함수, 매 프레임마다 호출됨
    {
        Debug.Log("Update called");
    }

    private void FixedUpdate()          // 물리 연산을 수행할 때 사용되는 함수, 일정한 시간 간격으로 호출됨
    {
        Debug.Log("FixedUpdate called");
    }
}
