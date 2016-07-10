# Problem 14:
"""Which starting number, under one million, produces the longest chain?"""
def collatzSequence(num):
    sequence, l = [num], 0
    while num > 1:
        if num % 2 == 0:
            num //= 2
        else:
            sequence.append(num)
            num = (3 * num + 1) // 2
        sequence.append(num)
    return sequence
def longest_Collatz_Sequence(limit):
    highestNum, highestLen = 0,0
    for i in range(1, limit,2):
        c = collatzSequence(i)
        if len(c) > highestLen:
            highestLen, highestNum = len(c), c[0]
            print(highestNum, highestLen)
    return highestNum
