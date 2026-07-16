using UnityEngine;


public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();        // GetComponentInParent : 부모 오브젝트에 있는 컴포넌트도 가져올 수 있음
    }

    private void EnableMovementAndJump() => player.EnableMovementAndJump(true);     // => : 람다식 (Lambda Expression)으로 메서드 정의, EnableMovementAndJump(true) 호출
    private void DisableMovementAndJump() => player.EnableMovementAndJump(false);
}
