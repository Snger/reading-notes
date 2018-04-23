# dash coin

<!-- MarkdownTOC -->

- Usage
- webapi basic
- testnet
- Bitcoin.conf Configuration File
- Data directory \(Win10\)
- Difference between bitcoin-tx, bitcoin-cli, and bitcoind?
- Bitcoind vs Bitcoin-cli Command Line Functions
- what is the difference between hard cap and soft cap in ethereum ICO

<!-- /MarkdownTOC -->

## Usage
> cd bicoin daemon dir
	$ btcdir
> first window, `./bitcoind.exe -datadir=../BitcoinData/ -debug -testnet`
	$ btcd
> second window, `./bitcoin-cli.exe -datadir=../BitcoinData/ -testnet getinfo`
	$ btccli getinfo (btccli getblockchaininfo)
> github/bitcoin, branch-master, cd bitcoin/share/rpcuser/, ./rpcuser.py <username>
> (in datadir) vi bitcoin.conf (https://github.com/bitcoin/bitcoin/blob/master/contrib/debian/examples/bitcoin.conf)

## webapi basic
> [bitcoin wiki - JSON-RPC](https://en.bitcoin.it/wiki/API_reference_%28JSON-RPC%29)
> - a list of RPC calls
	btccli -rpcwait help
> - getbestblockhash
> Returns the hash of the best (tip) block in the longest blockchain.
>> code: src/rpc/blockchain.cpp#178
	btccli getbestblockhash|pbcopy & echo $(pbpaste)
00000000837dbe9aa60c0456258be61a8f30266fd65ac643f0647ae8103dd2cc
> - getblock $hash
> (default) returns an Object with information about block <hash>.
>> code: src/rpc/blockchain.cpp#716
	btccli getblock $(pbpaste)
````json
{
  "hash": "00000000837dbe9aa60c0456258be61a8f30266fd65ac643f0647ae8103dd2cc",
  "confirmations": 1,
  "strippedsize": 22217,
  "size": 29097,
  "weight": 95748,
  "height": 1260615,
  "version": 536870912,
  "versionHex": "20000000",
  "merkleroot": "33dba02c0fd30dad54356bb4c728ee09abe20ea923d6011cdce418b15b757bd4",
  "tx": [
    "a2b4ea3933ce217583fadc5a838e7234ec0586702a54d8a0b9fe1f637366628c", 
    ...
  ],
  "time": 1516948417,
  "mediantime": 1516944549,
  "nonce": 3568421995,
  "bits": "1d00ffff",
  "difficulty": 1,
  "chainwork": "000000000000000000000000000000000000000000000034c02b5a971502089e",
  "previousblockhash": "0000000000000388a0cf65384f2d6777dcf43501687b8c22f6364bcace78a3e7"
}
````
> - getblockhash $height
> Returns hash of block in best-block-chain at height provided.
>> code: src/rpc/blockchain.cpp#632
	btccli getblockhash 1260615
00000000837dbe9aa60c0456258be61a8f30266fd65ac643f0647ae8103dd2cc
> - gettransaction $txid
>> gettransaction "txid" ( include_watchonly )
>> code: src/wallet/rpcwallet.cpp#2090
	btccli gettransaction a2b4ea3933ce217583fadc5a838e7234ec0586702a54d8a0b9fe1f637366628c
error code: -5
error message: Invalid or non-wallet transaction id


## testnet
1. Faucets: 
> https://testnet.manu.backend.hamburg/faucet
> http://bitcoinfaucet.uo1.net/send.php
> https://kuttler.eu/en/bitcoin/btc/faucet/
2. testnet addr: n4mgBtKnfpmLyhFEeSTWxR3MEgTyUkgNbJ
3. (Unable to connect to) http://bitcoinrpc:F2YkP9FYEdrHj2Ycg9eyxhNeN1848KoM2XJ2kem6Q3sd@localhost:18332
4. check address: https://testnet.blockexplorer.com/address/n4mgBtKnfpmLyhFEeSTWxR3MEgTyUkgNbJ

## Bitcoin.conf Configuration File
> All command-line options (except for -conf) may be specified in a configuration file, and all configuration file options may also be specified on the command line. Command-line options override values set in the configuration file.
> The configuration file is a list of setting=value pairs, one per line, with optional comments starting with the '#' character.
> The configuration file is not automatically created; you can create it using your favorite plain-text editor. A user-friendly configuration file generator is available here. By default, Bitcoin (or bitcoind) will look for a file named 'bitcoin.conf' in the bitcoin data directory, but both the data directory and the configuration file path may be changed using the -datadir and -conf command-line arguments.

## Data directory (Win10)
> 1. Bitcoin's data folder: C:\Users\YourUserName\Appdata\Roaming\Bitcoin
> 2. If you have already downloaded the data then you will have to move the data to the new folder. If you want to store them in D:\BitcoinData then click on "Properties" of a shortcut to bitcoin-qt.exe and add -datadir=D:\BitcoinData at the end.
> 3. Directory Contents
````
	.lock - Bitcoin data directory lock file
	bitcoin.conf [optional] - Contains configuration options.
	blkxxxx.dat [Versions prior to v0.8.0] - Contains concatenated raw blocks. Stored are actual Bitcoin blocks, in network format, dumped to disk raw.
	blkindex.dat [Versions prior to v0.8.0] - Indexing information used with blkxxxx.dat
	__db.xxx - Used by BDB
	db.log
	debug.log - Bitcoin's verbose log file. Automatically trimmed from time to time.
	wallet.dat - Storage for keys, transactions, metadata, and options. Please be sure to make backups of this file. It contains the keys necessary for spending your bitcoins.
	addr.dat [Versions prior to v0.7.0] - Storage for ip addresses to make a reconnect easier
	peers.dat [Versions v0.7.0 and later] - Storage for peer information to make a reconnect easier. This file uses a bitcoin-specific file format, unrelated to any database system[1].
	fee_estimates.dat [Versions v0.10.0 and later] - Statistics used to estimate fees and priorities. Saved just before program shutdown, and read in at startup.
	The data, index and log files are used by Oracle Berkeley DB, the embedded key/value data store that Bitcoin uses.
````

## Difference between bitcoin-tx, bitcoin-cli, and bitcoind?
> - bitcoind
The server version of bitcoin.
> - bitcoin-cli
This is a program that lets you issue commands to `bitcoind`. Example:
    # ./bitcoin-cli getblockcount
    326215
- bitcoin-tx
This is a program that can create, parse, or modify transactions. Example:
    # ./bitcoin-tx -json 0100000003ee7f90455d3f8d2d82da68d950b66f247331b5f13e7a5a56de1bc3b52f3bc43a810200008c493046022100a643127f3abb6d8a4d082bd66b9585a4e91a1e10bfce3ac749212b562f4a80560221008d68511acac655ce3df1dbda6a97cd74516ce2595a40e2e89a5168ba05be4c060141047723d175cc78e974ea686a67d44fbed02c81c9c4c9639a4f452e43354ec1baf53777ea0b4483d7a4022cd0ab20bd18b5ec07be9bde19d20e289c0211c066f7bfffffffffd909f8893803ceca676abb5669cd3800fa653c858e6ffbf940f56bc6201c1b1c6c0400008c493046022100c63b0d16f0f2377e14e08c8602af52be5e4411e20f2365c9fc0b439f4dabfa06022100ee1db39a12a5a855ea9ab9a96b817b86b78d55928afed7effa59454c7c19a0350141047723d175cc78e974ea686a67d44fbed02c81c9c4c9639a4f452e43354ec1baf53777ea0b4483d7a4022cd0ab20bd18b5ec07be9bde19d20e289c0211c066f7bfffffffff3b91021ed50547e5a2fe1fcb14112a244e37bb61fee2bc227fa4ac045c5341b0fa0300008b483045022100f0c4c72a693c1fd3413080a478d4fb983ad5ac5d23bdea1a3965b78fdb80192f02201838f4c63e103afdd89d257792f1bfcdfb992566bdf0757d2f2b9ca6e371aedc0141047723d175cc78e974ea686a67d44fbed02c81c9c4c9639a4f452e43354ec1baf53777ea0b4483d7a4022cd0ab20bd18b5ec07be9bde19d20e289c0211c066f7bfffffffff01c62e0000000000001976a91473242dd2a877025c8a0db539a7df5d9af6cdeb1988ac00000000
    {
        "txid": "8731eaae4520609d4ada30e23ee0f275b9dd62b72456a26dc0f137ae9fddd9b3",
        "version": 1,
        "locktime": 0,
        "vin": [
            {
                "txid": "3ac43b2fb5c31bde565a7a3ef1b53173246fb650d968da822d8d3f5d45907fee",
                "vout": 641,
                "scriptSig": {
                    "asm": "3046022100a643127f3abb6d8a4d082bd66b9585a4e91a1e10bfce3ac749212b562f4a80560221008d68511acac655ce3df1dbda6a97cd74516ce2595a40e2e89a5168ba05be4c0601 047723d175cc78e974ea686a67d44fbed02c81c9c4c9639a4f452e43354ec1baf53777ea0b4483d7a4022cd0ab20bd18b5ec07be9bde19d20e289c0211c066f7bf",
    ...
>> In addition, I would be interested to find out if there are any plans to further develop these into different, complementary, executables.
> No, there's no plan to change the scope of the programs. The most recent change was back in July 2014, which created `bitcoin-cli`, and removed that functionality from `bitcoind`.

## Bitcoind vs Bitcoin-cli Command Line Functions
> (August 19, 2014, 12:12:26 PM) bitcoind used to be the command you'd use in the past. In the future you should use bitcoin-cli. They are equivalent and bitcoind only works now for backwards compatibility.

## what is the difference between hard cap and soft cap in ethereum ICO
> A hard cap is defined as the maximum amount a crowdsale will receive. Most projects set a very high cap that is unlikely to happen. Only very famous projects like Status or Brave browser have reached its hard cap.
    contract crowdsale {
        uint public maximumEther;
        uint public totalEther;

        function () payable {
            // Do not accept payment if recaudation is above maximumEther
            if (totalEther + msg.value >= maximumEther) throw;

            // Emit tokens
            totalEther = totalEther + msg.value;
        }
    }
> A soft cap is the amount received at which your crowdsale will be considered a success. It is the minimal amount required by your project.
If you do not reach that amount during the ICO then you will allow the investors to retire their apport.
