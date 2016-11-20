import time

def champernownesConstant(*indexes):
    l, i, p = [], 0, 1
    while len(l) < max(indexes):
        i += 1
        for s in str(i):
            l.append(int(s))
    for ind in indexes:
        p *= l[ind-1]
    return p
s = time.clock()
print(champernownesConstant(1,10,100,1000,10000,100000,1000000), time.clock()-s)
