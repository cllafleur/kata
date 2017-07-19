#!/bin/python3

import time

def build_word_list():
    file = open('wordlist.txt', 'r')
    words = [str(word).rstrip('\n') for word in iter(lambda: file.readline(), '')]
    file.close()
    return words

def get_anagram_hash(word):
    hash_code = sorted(word.lower())
    return "".join(hash_code)

def build_collection_grouped_anagrams(words):
    hashset = {}
    result_collection = []
    for word in words:
        hash_code = get_anagram_hash(word)
        item = hashset.get(hash_code)
        if item is None:
            anagrams = []
            result_collection.append(anagrams)
            hashset[hash_code] = anagrams
        else:
            anagrams = item
        anagrams.append(word)
    return result_collection

def run():
    anagram_group_count = 0
    words = build_word_list()
    start_time = time.time()
    result = build_collection_grouped_anagrams(words)
    end_time = (time.time() - start_time)
    for item in result:
        if len(item) > 1:
            anagram_group_count += 1
            print(" ".join(item))
    print("-- %s seconds --" % end_time)
    print("Words count          : %10d" % len(words))
    print("Anagram groups count : %10d" % anagram_group_count)

if __name__ == '__main__':
    run()
