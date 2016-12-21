def pentagonalNumbers():
    nums, diff = set([((3*i*i)-i)/2 for i in range(3,3000)]), 9999999
    for j in nums:
        for n in nums:
            if n+j in nums and n-j in nums and n-j < diff:
                diff = n-j
    return diff

print(pentagonalNumbers())
