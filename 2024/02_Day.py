
def read_file():
    with open('01_Input.txt', 'r') as file:
        row = file.readlines()
    return row

#---------------------------------------------------------

# MAIN
row = read_file()

