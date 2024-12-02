
def read_file():
    with open('01_Input.txt', 'r') as file:
        row = file.readlines()
    return row

#---------------------------------------------------------

# MAIN
row = read_file()
ListA = []
ListB = []

for i, item in enumerate(row):
    ListA.append(int(item.split()[0]))
    ListB.append(int(item.split()[1]))

# part_1
ListA.sort()
ListB.sort()

totalDistance = 0

for i in range(len(ListA)):
    totalDistance += abs(ListA[i] - ListB[i])

print(totalDistance)


#part_2
totalSimilarity = 0
similarity = 0

for i, itemA in enumerate(ListA):
    for j, itemB in enumerate(ListB):
        if itemA == itemB : similarity += 1
    totalSimilarity += int(itemA) * similarity
    similarity = 0

print(totalSimilarity)

# END
