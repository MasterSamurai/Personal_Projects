# Problem 31:
"""How many different ways can £2 be made using any number of coins?"""
coins = [1,2,5,10,20,50,100,200]

def diff_Combinations_Coins(coin_denominations, target):
    c = [1] + [0]*target
    for coin in coin_denominations:
        for i in range(coin,target+1):
            c[i] += c[i-coin]
    return c[target]
