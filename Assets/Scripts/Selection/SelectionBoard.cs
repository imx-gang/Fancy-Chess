using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Game;
using Chess;

public class SelectionBoard : MonoBehaviour
{
    MeshRenderer[, ] squareRenderers;
    SpriteRenderer[, ] squarePieceRenderers;
    public BoardTheme boardTheme;
    public float cellSize = 1;

    public bool whiteIsBottom = true;
    const float pieceDepth = -0.1f;

    const int rankCount = 2;
    const int fileCount = 8;


    // Start is called before the first frame update
    void Start()
    {
        CreateBoardUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBoardUI () {

        Shader squareShader = Shader.Find ("Unlit/Color");
        squareRenderers = new MeshRenderer[fileCount, rankCount];
        squarePieceRenderers = new SpriteRenderer[fileCount, rankCount];

        for (int rank = 0; rank < rankCount; rank++) {
            for (int file = 0; file < fileCount; file++) {
                // Create square
                Transform square = GameObject.CreatePrimitive (PrimitiveType.Quad).transform;
                square.parent = transform;
                square.name = BoardRepresentation.SquareNameFromCoordinate (file, rank);
                square.position = PositionFromCoord (file, rank, 0);
                Material squareMaterial = new Material (squareShader);

                squareRenderers[file, rank] = square.gameObject.GetComponent<MeshRenderer> ();
                squareRenderers[file, rank].material = squareMaterial;

                // Create piece sprite renderer for current square
                SpriteRenderer pieceRenderer = new GameObject ("Piece").AddComponent<SpriteRenderer> ();
                pieceRenderer.transform.parent = square;
                pieceRenderer.transform.position = PositionFromCoord (file, rank, pieceDepth);
                pieceRenderer.transform.localScale = Vector3.one * 100 / (2000 / 6f);
                squarePieceRenderers[file, rank] = pieceRenderer;
            }
        }

        ResetSquareColours ();
    }


    public void ResetSquareColours (bool highlight = true) {
        for (int rank = 0; rank < rankCount; rank++) {
            for (int file = 0; file < fileCount; file++) {
                SetSquareColour (new Coord (file, rank), boardTheme.lightSquares.normal, boardTheme.darkSquares.normal);
            }
        }
    }

    void SetSquareColour (Coord square, Color lightCol, Color darkCol) {
        squareRenderers[square.fileIndex, square.rankIndex].material.color = (square.IsLightSquare ()) ? lightCol : darkCol;
    }

    public Vector3 PositionFromCoord (int file, int rank, float depth = 0) {
        if (whiteIsBottom) {
            return new Vector3 (-cellSize * (fileCount-1)/2 + file, -cellSize * (rankCount-1)/2 + rank, depth);
        }
        return new Vector3 (cellSize * (fileCount-1)/2 - file, (rank-1)/2 - rank, depth);

    }

    public Vector3 PositionFromCoord (Coord coord, float depth = 0) {
        return PositionFromCoord (coord.fileIndex, coord.rankIndex, depth);
    }
}
