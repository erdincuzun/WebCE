#2. Univariate feature selection
from sklearn.feature_selection import SelectKBest
import pandas as pd

#For classification: chi2, f_classif, mutual_info_classif
#If you use sparse data (i.e. data represented as sparse matrices), chi2, mutual_info_regression, mutual_info_classif will deal with the data without making it dense.
def SelectKBest_selector(data, target, number, sf):
    selector = SelectKBest(score_func=sf, k=number)
    data_new = selector.fit_transform(data.values, target.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(data.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

#http://scikit-learn.org/stable/modules/generated/sklearn.feature_selection.SelectPercentile.html#sklearn.feature_selection.SelectPercentile
from sklearn.feature_selection import SelectPercentile
def SelectPercentile_selector(data, target, per, sf):
    selector = SelectPercentile(score_func=sf, percentile=per)
    data_new = selector.fit_transform(data.values, target.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(data.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

#http://scikit-learn.org/stable/modules/generated/sklearn.feature_selection.SelectFpr.html#sklearn.feature_selection.SelectFpr
from sklearn.feature_selection import SelectFpr
def SelectFpr_selector(data, target, sf):
    selector = SelectFpr(score_func=sf)
    data_new = selector.fit_transform(data.values, target.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(data.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

#http://scikit-learn.org/stable/modules/generated/sklearn.feature_selection.SelectFdr.html#sklearn.feature_selection.SelectFdr
from sklearn.feature_selection import SelectFdr
def SelectFdr_selector(data, target, sf):
    selector = SelectFdr(score_func=sf)
    data_new = selector.fit_transform(data.values, target.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(data.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

#http://scikit-learn.org/stable/modules/generated/sklearn.feature_selection.SelectFwe.html#sklearn.feature_selection.SelectFwe
from sklearn.feature_selection import SelectFwe
def SelectFwe_selector(data, target, sf):
    selector = SelectFwe(score_func=sf)
    data_new = selector.fit_transform(data.values, target.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(data.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)