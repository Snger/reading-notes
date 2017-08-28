## Usage
1. `./bitcoind.exe -datadir=../BitcoinData/ -debug -testnet`
2. `./bitcoin-cli.exe -datadir=../BitcoinData/ -testnet getinfo`
3. github/bitcoin, branch-master, cd bitcoin/share/rpcuser/, ./rpcuser.py <username>
4. (in datadir) vi bitcoin.conf (https://github.com/bitcoin/bitcoin/blob/master/contrib/debian/examples/bitcoin.conf)

## testnet
1. Faucets: 
> https://testnet.manu.backend.hamburg/faucet
> http://bitcoinfaucet.uo1.net/send.php
> https://kuttler.eu/en/bitcoin/btc/faucet/
2. testnet addr: n4mgBtKnfpmLyhFEeSTWxR3MEgTyUkgNbJ
3. (Unable to connect to) http://bitcoinrpc:F2YkP9FYEdrHj2Ycg9eyxhNeN1848KoM2XJ2kem6Q3sd@localhost:18332
4. check address: https://testnet.blockexplorer.com/address/n4mgBtKnfpmLyhFEeSTWxR3MEgTyUkgNbJ

## Data directory (Win10)
1. Bitcoin's data folder: C:\Users\YourUserName\Appdata\Roaming\Bitcoin
2. If you have already downloaded the data then you will have to move the data to the new folder. If you want to store them in D:\BitcoinData then click on "Properties" of a shortcut to bitcoin-qt.exe and add -datadir=D:\BitcoinData at the end.
3. Directory Contents
> .lock - Bitcoin data directory lock file
> bitcoin.conf [optional] - Contains configuration options.
> blkxxxx.dat [Versions prior to v0.8.0] - Contains concatenated raw blocks. Stored are actual Bitcoin blocks, in network format, dumped to disk raw.
> blkindex.dat [Versions prior to v0.8.0] - Indexing information used with blkxxxx.dat
> __db.xxx - Used by BDB
> db.log
> debug.log - Bitcoin's verbose log file. Automatically trimmed from time to time.
> wallet.dat - Storage for keys, transactions, metadata, and options. Please be sure to make backups of this file. It contains the keys necessary for spending your bitcoins.
> addr.dat [Versions prior to v0.7.0] - Storage for ip addresses to make a reconnect easier
> peers.dat [Versions v0.7.0 and later] - Storage for peer information to make a reconnect easier. This file uses a bitcoin-specific file format, unrelated to any database system[1].
> fee_estimates.dat [Versions v0.10.0 and later] - Statistics used to estimate fees and priorities. Saved just before program shutdown, and read in at startup.
> The data, index and log files are used by Oracle Berkeley DB, the embedded key/value data store that Bitcoin uses.

