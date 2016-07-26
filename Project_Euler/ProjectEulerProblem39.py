# Problem 39:
"""For which value of p ≤ 1000, is the number of solutions maximised?"""
def findTrianglePairs(num):
    pairs = 0
    for i in range(int(num**0.5), (num//2)+1,2):
        for j in range(i, (num//2)+1,2):
            k = ((i**2 + j**2)**0.5) // 1
            if k == num-i-j and i**2 + j**2 == k**2:
                pairs += 1
    return pairs
def integerRightTriangles(limit):
    maxNum, maxPer = 0,0
    if limit % 10 == 0:
        for i in range(limit, limit//4, -10):
            num = findTrianglePairs(i)
            if num > maxPer:
                maxNum, maxPer = i, num
    return maxNum
