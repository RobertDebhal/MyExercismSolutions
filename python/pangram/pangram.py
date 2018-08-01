def is_pangram(sentence):
    alphabet='abcdefghijklmnopqrstuvwxyz'
    check=[0 for i in range(26)]
    for letter in sentence:
        if letter.lower() in alphabet:
            check[alphabet.index(letter.lower())]=1
    for i in check:
        if i==0:
            return False
    return True



