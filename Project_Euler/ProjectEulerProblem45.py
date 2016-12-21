def tri_Penta_Hexa_Number():
    t = set([(n*(n+1))/2 for n in range(1,100000)])
    p = set([(n*(3*n-1))/2 for n in range(1,100000)])
    h = set([n*(2*n-1) for n in range(1,100000)])
    return max(set(h).intersection(set(t).intersection(p)))

tri_Penta_Hexa_Number()
