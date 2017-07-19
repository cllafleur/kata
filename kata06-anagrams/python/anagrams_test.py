#!/bin/python3

import unittest
import anagrams

class anagram_hashcode_tests(unittest.TestCase):
    def test_anagramHash_isWordWithLowerCharsSorted(self):
        word = 'test'
        expected_hash = 'estt'
        result = anagrams.get_anagram_hash(word)
        self.assertEqual(result, expected_hash)

    def test_anagramHash_isWordWithUpperAndLowerCharsSorted(self):
        word = 'Test'
        expected_hash = 'estt'
        result = anagrams.get_anagram_hash(word)
        self.assertEqual(result, expected_hash)

class anagrams_grouped_tests(unittest.TestCase):
    def test_wordsWithOneAnagram_returnsOneAnagramGroup(self):
        words = ['test', 'sett', 'stet']
        expected_groups = [['test', 'sett', 'stet']]
        result = anagrams.build_collection_groupedAnagrams(words)
        self.assertEqual(result, expected_groups)

    def test_wordsWithOneAnagram_returnsTwoAnagramGroup(self):
        words = ['test', 'main', 'sett', 'stet', 'ainm', 'niam']
        expected_groups = [['test', 'sett', 'stet'], ['main', 'ainm', 'niam']]
        result = anagrams.build_collection_groupedAnagrams(words)
        self.assertEqual(result, expected_groups)

if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(anagram_hashcode_tests)
    suite2 = unittest.TestLoader().loadTestsFromTestCase(anagrams_grouped_tests)
    alltests = unittest.TestSuite([suite, suite2])
    unittest.TextTestRunner(verbosity=2).run(alltests)
