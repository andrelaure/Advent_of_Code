def read_file():
    with open('04_Input.txt', 'r') as file:
        row = file.readlines()
    return row


#-------------------------------------------------------------------------------
#MAIN

records = read_file()
sample = [["MMMSXXMASM"],
          ["MSAMXMSMSA"],
          ["AMXSXMAAMM"],
          ["MSAMASMSMX"],
          ["XMASAMXAMM"],
          ["XXAMMXXAMA"],
          ["SMSMSASXSS"],
          ["SAXAMASAAA"],
          ["MAMMMXMMMM"],
          ["MXMXAXMASX"]]

xmas_counter = 0

for row in sample:
    for ch in row:
        if ch == 'X':


print (sample)
#END 
