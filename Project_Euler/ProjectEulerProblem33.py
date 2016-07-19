# Problem 33:
"""If the product of these four fractions is given in its lowest common terms, find the value of the denominator."""
def isNonTrivialCuriousFraction(numerator, denominator):
    numer = [int(x) for x in str(numerator)]
    denom = [int(y) for y in str(denominator)]
    if numerator/denominator < 1:
        for i in numer:
            for j in denom:
                if i == 0:
                    return False
                if i == j:
                    numer.remove(i)
                    denom.remove(i)
    newNumerator, newDenominator = int("".join(str(d) for d in numer)), int("".join(str(d) for d in denom))
    try:
        if newNumerator/newDenominator == numerator/denominator and newNumerator != numerator and newDenominator != denominator:
            return True
    except ZeroDivisionError:
        return False
def productNonTrivialCuriousFractions():
    fracs, nums, denoms = [],1,1
    for i in range(10,100):
        for j in range(10,100):
            if isNonTrivialCuriousFraction(i,j):
                fracs.append([i,j])
    for k in fracs:
        nums *= k[0]
        denoms *= k[1]
    return denoms/nums
