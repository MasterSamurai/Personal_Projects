import math

def is_Prime(n):
    return not any([n % i == 0 for i in range(2, int(math.sqrt(n))+1)])

n = 0
p = [j for j in range(2,10000) if is_Prime(j)]
for i in p:
    if n < 1000000 and n+i < 1000000:
        n += i
        continue
    else:
        print(n)
        break

i = -1
while not is_Prime(n):
    i += 1
    n -= p[i]

print(n)
