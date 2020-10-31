using System;


namespace DecentralizedBandwidth
{
    partial class Program
    {
        [Serializable]
        class Block : Serializer
        {
            //Public variables
            public string Hash { get { return ""; } }
            public int BlockSize { get { return getBlockSize(); } }
            public long BlockID { get; private set; }
            public DateTime TimeStamp { get; private set; }
            public Transaction[] TransactionList { get { return transactions; } }

            //Private Variables
            private Transaction[] transactions = null;

            public Block(Transaction[] transactions)

            {
                BlockID = 0;
                this.transactions = new Transaction[getObjectListFilesize(transactions)];
            }

            private int getBlockSize()
            {
                return getObjectListFilesize(new Block[1] { this });
            }


            
        }
    }
}
