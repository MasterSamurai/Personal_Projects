# Problem 15:
"""Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down,
there are exactly 6 routes to the bottom right corner. How many such routes are there through a 20×20 grid?"""
def find_paths(grid_size):
    paths = 1
    for i in range(0,grid_size):
        paths *= (2*grid_size - i)
        paths //= (i + 1)
    return paths
print(find_paths(20))
