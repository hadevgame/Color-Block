using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroShadow : MonoBehaviour
{
    public Color shadowColor; // Màu của bóng
    public LayerMask blockLayer; // Layer chứa các ô vuông của lưới

    private void Update()
    {
        // Lấy vị trí của Tetromino
        Vector3 tetrominoPos = transform.position;

        // Lựa chọn vị trí dưới của Tetromino
        Vector3 shadowPos = new Vector3(tetrominoPos.x, tetrominoPos.y - 1, tetrominoPos.z);

        // Tìm ô vuông dưới Tetromino
        RaycastHit2D hit = Physics2D.Raycast(shadowPos, Vector2.down, 0, blockLayer);

        if (hit.collider != null)
        {
            // Nếu tìm thấy ô vuông, làm đậm màu của ô đó
            hit.collider.GetComponent<SpriteRenderer>().color = shadowColor;
        }
    }
}
