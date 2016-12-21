import math

def is_Prime(n):
    return not any([n % i == 0 for i in range(2, int(math.sqrt(n))+1)])

def find_Conjecture_Failure():
    p = set([i for i in range(1,10000,2) if is_Prime(i)])
    for i in range(1,10000,2):
        if not is_Prime(i):
            if all((a + 2*(b**2)) != i for b in range(2,int(math.sqrt(i))) for a in p):
                return i

print(find_Conjecture_Failure())
