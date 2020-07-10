empty_set = set()
print('empty_set ->', empty_set)
alpha = set(('a', 'b', 'c', 'd'))
print('alpha ->', alpha)
dup_list = ['c', 'd', 'c', 'd', 'e', 'f']
beta = set(dup_list)
print('beta ->', beta)
uniq_list = list(beta)
print('uniq_list ->', uniq_list)

gamma = alpha.union(beta)
print('gamma ->', gamma)
gamma = alpha | beta
print('gamma ->', gamma)

delta = alpha.intersection(beta)
print('delta ->', delta)
delta = alpha & beta
print('delta ->', delta)

epsilon = alpha.difference(beta)
print('epsilon ->', epsilon)
epsilon = alpha - beta
print('epsilon ->', epsilon)

eta = alpha.symmetric_difference(beta)
print('eta ->', eta)
eta = alpha ^ eta
print('eta ->', eta)

print('epsilon.isdisjoint(delta) ->', epsilon.isdisjoint(delta))
print('epsilon.isdisjoint(eta) ->', epsilon.isdisjoint(eta))

print('epsilon.issubset(eta) ->', epsilon.issubset(eta))
print('epsilon.issubset(beta) ->', epsilon.issubset(beta))

print('eta.issuperset(epsilon) ->', eta.issuperset(epsilon))
print('beta.issuperset(epsilon) ->', beta.issuperset(epsilon))

feta = frozenset(eta)
print('feta ->', feta)

zeta = set()
print('zeta ->', zeta)
zeta.add(3)
print('zeta ->', zeta)
zeta.add(3)
print('zeta ->', zeta)
zeta.add(4)
print('zeta ->', zeta)

print('gamma->', gamma)
gamma.discard('a')
print('gamma->', gamma)
gamma.discard('z')
print('gamma->', gamma)
gamma.remove('b')
print('gamma->', gamma)
random_element = gamma.pop()
print('random_element ->', random_element)
print('gamma->', gamma)
zeta_ref = zeta
zeta_copy = zeta.copy()
print('zeta ->', zeta)
print('zeta_ref ->', zeta_ref)
print('zeta_copy ->', zeta_copy)

print('alpha ->', alpha)
alpha_diff = alpha.copy()
alpha_diff.difference_update(beta)
print('alpha_diff ->', alpha_diff) 

alpha_intersect = alpha.copy()
alpha_intersect.intersection_update(beta)
print('alpha_intersect ->', alpha_intersect) 

alpha_sym_diff = alpha.copy()
alpha_sym_diff.symmetric_difference_update(beta)
print('alpha_sym_diff ->', alpha_sym_diff) 

alpha_union = alpha.copy()
alpha_union.update(beta)
print('alpha_union ->', alpha_union) 













