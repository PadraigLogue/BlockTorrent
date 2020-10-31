using DecentralizedBandwidth;
using System;
using System.Collections.Generic;
using System.Linq;

//this class encompasses the actual files that are going to be transmitted
//helpful: http://dandylife.net/docs/BitTorrent-Protocol.pdf
public class Transaction : Serializer
{
    public string Author { get; private set; }
    public int FileSize { get; private set; }
    public string FileName { get; private set; }
    public Piece[] Pieces { get; private set; }
    public string PiecesHash { get; private set; }

    private DateTime TransactionExpiry;
    private DateTime TransactionTimestamp;
    private int pieceSize = 256000;
    public Transaction(string fileName, byte[] content, string author, DateTime transactionExpiry)
    {
        Author = author;
        TransactionTimestamp = DateTime.Now;
        TransactionExpiry = transactionExpiry;
        FileSize = content.Length;
        FileName = fileName;
        Pieces = createFilePieces(content, pieceSize);
        PiecesHash = createPiecesHash();
    }

    public bool isExpired()
    {
        return TransactionTimestamp > TransactionExpiry;
    }

    //memory will be filled with the file's contents
    //needs fixed. write to a file...
    private Piece[] createFilePieces(byte[] content, int pieceSize)
    {
        List<Piece> Pieces = new List<Piece>();

        //If the chunk size is larger than the file itself, halve it until you have an appropriate chunk size. 
        while (content.Length < pieceSize)
        {
            pieceSize /= 2;
        }

        int iterations = content.Length / pieceSize;
        for (int i = 0; i <= iterations; i++)
        {
            //change buffer size to accommodate remaining bytes
            if ((content.Length % pieceSize) != 0 && i == iterations)
            {
                pieceSize = content.Length % pieceSize;
            }

            byte[] pieceBuffer = new byte[pieceSize];
            Array.Copy(content, i * pieceSize, pieceBuffer, 0, pieceSize);

            string pieceHash = Hashing.computeByteHash(pieceBuffer);
            Piece piece = new Piece(pieceSize, pieceBuffer, pieceHash);
            Pieces.Add(piece);
        }

        return Pieces.ToArray();
    }

    private string createPiecesHash()
    {
        IEnumerable<string> hashes = from piece in Pieces select piece.Piece_Hash;
        return string.Join("", hashes);
    }
}
public struct Piece
{
    public int Piece_Length;
    public byte[] File_Piece;
    public string Piece_Hash;

    public Piece(int piece_Length, byte[] piece, string pieceHash)
    {
        Piece_Length = piece_Length;
        File_Piece = piece;
        Piece_Hash = pieceHash;
    }
}