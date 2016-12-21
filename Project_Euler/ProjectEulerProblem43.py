import itertools

def sumPandigital():
    s = 0
    for i in itertools.permutations('1406357289', 10):
        j = ''.join(i)
        list, nums = [int(i) for i in j], [0, 2, 3, 5, 7, 11, 13, 17]
        if all((list[i]*100 + list[i+1]*10 + list[i+2]) % nums[i] == 0 for i in range(1,len(j)-2)):
            s += int(j)
    return s

print(sumPandigital())
