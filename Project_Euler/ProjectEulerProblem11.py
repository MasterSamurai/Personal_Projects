# Problem 11
"""What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?"""
grid = list(open('grid.txt', 'r', encoding='utf-8', newline=None))
grid = [s.rstrip() for s in grid]
grid = [s.replace(' ', ', ')for s in grid]
def greatest_Adjacent_Product(grid, cols, rows):
    i = -1
    highest = 0
    for s, l in zip(grid, grid[i]):
        i += 1
        grid[i] = s.split(',')
        j = []
        for l in grid[i]:
            j.append(int(l))
            grid[i] = j
    for column in range(cols+1):
        for row in range(rows+1):
            try:
                a = grid[column][row] * grid[column+1][row] * grid[column+2][row] * grid[column+3][row]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column - 1][row] * grid[column - 2][row] * grid[column - 3][row]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column + 1][row + 1] * grid[column + 2][row + 2] * grid[column + 3][row + 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column - 1][row - 1] * grid[column - 2][row - 2] * grid[column - 3][row - 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column][row + 1] * grid[column][row + 2] * grid[column][row + 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column][row - 1] * grid[column][row - 2] * grid[column][row - 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column - 1][row + 1] * grid[column - 2][row + 2] * grid[column - 3][row + 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
            try:
                a = grid[column][row] * grid[column + 1][row - 1] * grid[column + 2][row - 2] * grid[column + 3][row - 3]
                if a > highest:
                    highest = a
            except IndexError:
                pass
    return highest
