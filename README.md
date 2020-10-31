# BlockTorrent
An extension of a bittorrent style protocol to facilitate P2P filetransfer and reward seeders with cryptocurrency. Consensus is built on trust from clients who have done "work" i.e successfully delivered a file 'piece' which is 256kb maximum(this could be adapted). 5 nodes make up a unit and they elect 1 speaker who acts as a mediator between them, they are voted in democratically based on which node has the highest trust score. The idea is that content can be distributed using 5 node cell structures that deliver content, each structure being a mini web/video streaming server that does not know the identities of other structures. This could be described as a possible solution to the byzantine generals problem and could be adapted so that it costs cryptocurrency to place adverts on a website OR it costs money to distribute over a certain amount of bandwidth. DBFT aims to deliver the best balance between throughput and a blockchain consensus that can be trusted. As long as 1/3 or less of nodes are bad actors(double spending attacks, etc) the chain's integrity can be maintained. 
