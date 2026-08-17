#include "stdafx.h"
#include "GraphDemoFunctions.h"

/*
Hash Function properties:

Deterministic: The same input will always produce the same output.(no randomness)

Uniform: A good hash function should distribute the input values uniformly across the output range to minimize collisions.

Diffusion and confusion: Small changes in the input should produce significant changes in the output to make it difficult to predict the hash value. typically in crypto functions


*/

/*
* Adapted from training on www.percipio.com
DJB Function: from Daniel J. Bernstein, a widely used hash function for strings.

*/
size_t djb_hash(const string& str) {
	size_t hash = 5381; // Starting with a large prime number
	for (char c : str) {
		hash = ((hash << 5) + hash) + c; // hash * 33 + c
	}
	return hash;
}

 int main() {

	 cout << "Hash Function Demo" << endl;
	string input = "Steve";
	size_t hashValue = djb_hash(input);
	cout << "Input: " << hex << input << endl;
	cout << "DJB Hash Value: " << hashValue << endl;

	input = "Steve";
	//2. Test with standard library hash function for comparison Fowler-Noll-Vo (FNV) hash function
	hashValue = std::hash<string>()(input);
	cout << "Input: " << hex << input << endl;
	cout << "Std Hash Value: " << hashValue << endl;


	// Demonstrating that the same input produces the same hash value
	string input2 = "Steve";
	size_t hashValue2 = djb_hash(input2);
	cout << "Input: " << input2 << endl;
	cout << "Hash Value: " << hex << hashValue2 << endl;
	// Demonstrating that different inputs produce different hash values
	string input3 = "Goodbye, World!";
	size_t hashValue3 = djb_hash(input3);
	cout << "Input: " << hex << input3 << endl;
	cout << "Hash Value: " << hashValue3 << endl;

	//3. Hash function for unordered_map<string, string> function
	unordered_map<string, string> m1;
	unordered_map<string, string>::hasher hashFunc = m1.hash_function();
	cout << "unordered maphasher: " << hex << hashFunc("Steve") << endl;
	
	//3. Replace Hasher
	
	unordered_map<string, string, function<decltype(djb_hash)>> m2(10, djb_hash);
	m2["Steve"] = "OK";
	cout << m2["Steve"] << endl;

    //Graph adjacency list demo
	cout << "Graph Adjacency List Demo" << endl;
	AdjacencyList();

	//Graph adjacency matrix demo
	cout << "Graph Adjacency Matrix Demo" << endl;
	AdjacencyMatrix();

	//Depth First Search demo
	cout << "Depth First Search Demo" << endl;
	DepthFirstSearchDemo();

	//Breadth First Search demo
	cout << "Breadth First Search Demo" << endl;
	BreadthFirstSearchDemo();

	//Topological Sort demo
	cout << "Topological Sort Demo" << endl;
	TopologicalSortDemo();
	return 0;
 }