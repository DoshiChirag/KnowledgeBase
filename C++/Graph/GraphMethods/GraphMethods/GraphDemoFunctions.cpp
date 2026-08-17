#include "stdafx.h"

int AdjacencyList() {
	//adjacency list representation of a graph map from a node 'id' to a list of its neighboring node 'ids' (vector<int>)
	map<int, vector<int>>  adj;

	// vertex 1 connected to vertex 2
	vector<int> n1 = { 2 };
	adj.insert(make_pair( 1, n1 ));

	// vertex 2 connected to vertices 1 and 3
	vector<int> n2 = { 1, 3 };
	adj.insert(make_pair(2, n2));

	// vertex 3 connected to vertex 2
	vector<int> n3 = {2};
	adj.insert(make_pair(3, n3));

	size_t count = adj.size(); // 2
	for(int i =1; i<=count ; i++) {
		cout << "Node " << i << " is connected to: ";
		for(int j : adj[i]) {
			cout << j << " ";
		}
		cout << endl;
	}

	return 0;
}


int AdjacencyMatrix() {
	//adjacency matrix representation of a graph
	// 0 1 0 1
	// 1 0 1 0
	// 0 1 0 1
	// 1 0 1 0
	vector<vector<int>> adj = {
		{0, 1, 0, 1},
		{1, 0, 1, 0},
		{0, 1, 0, 1},
		{1, 0, 1, 0}
	};
	size_t count = adj.size(); // 4
	for(int i =0; i<count ; i++) {
		cout << "Node " << i+1 << " is connected to: ";
		for(int j =0; j<count; j++) {
			if(adj[i][j] == 1) {
				cout << j+1 << " ";
			}
		}
		cout << endl;
	}
	return 0;
}

// Breadth First Search (BFS) implementation
// BFS explores the graph level by level, starting from the given node and visiting all its neighbors before moving to the next level of neighbors.
bool BreadthFirstSearch(const map<int, vector<int>>& adj, int start, int target) {
	bool target_found = false;
	bool* visited = new bool[adj.size() + 1](); // +1 to account for 1-based indexing
	for(int i = 0; i <= adj.size(); i++) {
		visited[i] = false;
	}
	queue<int> q;
	q.push(start);
	visited[start] = true;


	cout << "BFS starting from node " << start << " to find node " << target << endl;
	while(!q.empty()) {
		int current = q.front();
		q.pop();
		cout << "Visiting node: " << current << endl;
		if(current == target) {
			target_found = true;
			break;
		}
		for(int neighbor : adj.at(current)) {
			if(!visited[neighbor]) {
				q.push(neighbor);
				visited[neighbor] = true;
			}
		}
	}

	delete[] visited;
	cout << endl;

	return target_found;
}

void BreadthFirstSearchDemo() {
	map<int, vector<int>> adj = {
		{1, {2, 3}},
		{2, {1, 4}},
		{3, {1, 4}},
		{4, {2, 3, 4, 5, 6}},
		{5, {4}},
		{6, {4}}
	};

	cout << boolalpha << BreadthFirstSearch(adj, 1, 6) << endl;
	cout << boolalpha << BreadthFirstSearch(adj, 1, 4) << endl;
	cout << boolalpha << BreadthFirstSearch(adj, 1, 7) << endl;

}

// Depth First Search (DFS) implementation
// Note: This implementation uses an iterative approach with a stack to avoid potential stack overflow issues with deep recursion.
bool DepthFirstSearch(const map<int, vector<int>>& adj, int start, int target) {
	bool target_found = false;
	bool* visited = new bool[adj.size() + 1](); // +1 to account for 1-based indexing
	for (int i = 0; i <= adj.size(); i++) {
		visited[i] = false;
	}

	stack<int> s;
	s.push(start);
	cout << "DFS starting from node " << start << " to find node " << target << endl;
	while (!s.empty()) {
		int current = s.top();
		s.pop();
		cout << "Visiting node: " << current << endl;
		if (current == target) {
			target_found = true;
			break;
		}

		
		for (int neighbor : adj.at(current)) {
			if (!visited[neighbor]) {
				s.push(neighbor);
				visited[neighbor] = true;
			}
		}
		
	}

	delete[] visited;
	cout << endl;

	return target_found;

	return false;
}

void DepthFirstSearchDemo(){
	map<int, vector<int>> adj = {
		{1, {2, 3}},
		{2, {1, 4}},
		{3, {1, 4}},
		{4, {2, 3, 4, 5, 6}},
		{5, {4}},
		{6, {4}}
	};

	cout << boolalpha << DepthFirstSearch(adj, 1, 6) << endl;
	cout << boolalpha << DepthFirstSearch(adj, 1, 4) << endl;
	cout << boolalpha << DepthFirstSearch(adj, 1, 7) << endl;


}

template<size_t cols>
vector<int> topsort(int adj[][cols]){ 
	vector<int> v;
	unordered_set<int> s;//current set of nodes with no incoming edges
	
	for (int i = 0; i < cols; i++) {
		bool hasIncomingEdge = false;
		for (int j = 0; j < cols; j++) {
			if (adj[j][i] == 1) {
				hasIncomingEdge = true;
				break;
			}
		}
		if (!hasIncomingEdge) {
			s.insert(i);
		}
	}

	while(!s.empty()){
		int n = *s.begin();
		s.erase(n);
		v.push_back(n);
		cout << "Processing node: " << n + 1 << endl;
		for(int j = 0; j < cols; j++) {
			if(adj[n][j] == 1) {
				adj[n][j] = 0;
				bool hasIncomingEdge = false;
				for(int k = 0; k < cols; k++) {
					if(adj[k][j] == 1) {
						hasIncomingEdge = true;
						break;
					}
				}
				if(!hasIncomingEdge) {
					s.insert(j);
				}
			}
		}
	}
	

	if(v.size() != cols) {
		cout << "Graph has a cycle, topological sort not possible." << endl;
		v.clear(); // Clear the vector to indicate failure
	}

	return v;
}

// Topological Sort implementation
void TopologicalSortDemo() {
	// Example graph represented as an adjacency list
	int adj[6][6] = {
		{0, 1, 1, 0, 0, 0},
		{0, 0, 0, 1, 0, 0},
		{0, 0, 0, 0, 1, 0},
		{0, 0, 0, 0, 0, 1},
		{0, 0, 0, 0, 0, 1},
		{0, 0, 0, 0, 0, 0}
		
	};
	vector<int> t = topsort(adj);

	if(t.empty()) {
		cout << "The graph has a cycle, topological sort not possible." << endl;
	} else {
		cout << "Topological Sort Order: ";
		for(int node : t) {
			cout << (node+1) << " ";
		}
	}

	int adj2[6][6] = {
		{0, 1, 1, 0, 0, 0},
		{0, 0, 0, 1, 0, 0},
		{0, 0, 0, 0, 1, 0},
		{0, 0, 0, 0, 0, 1},
		{0, 0, 0, 1, 0, 0},
		{0, 0, 0, 0, 1, 0}

	};

	cout << endl << "Adjacency Matrix for Graph with Cycle:" << endl;
	for(int i = 0; i < 6; i++) {
		for(int j = 0; j < 6; j++) {
			cout << adj2[i][j] << " ";
		}
		cout << endl;
	}

	cout << endl;
	t = topsort(adj2);
	cout << endl;
}

