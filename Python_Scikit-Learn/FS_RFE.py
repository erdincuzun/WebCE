#3. Recursive feature elimination
from sklearn.feature_selection import RFE
from sklearn.feature_selection import RFECV
from sklearn.tree import DecisionTreeClassifier
from sklearn.svm import SVR
import pandas as pd

from data_processing import *

def SelectRFE_DT(dataf, targetf):
    estimator = DecisionTreeClassifier()
    selector = RFE(estimator)
    data_new = selector.fit_transform(dataf.values, targetf.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(dataf.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

def SelectRFE_DTCV(dataf, targetf):
    estimator = DecisionTreeClassifier()
    selector = RFECV(estimator, cv = 3)
    data_new = selector.fit_transform(dataf.values, targetf.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(dataf.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)

#too slow, so this method is eliminated
def SelectRFE_SVR(dataf, targetf):
    estimator = SVR(kernel="linear")
    selector = RFE(estimator)
    data_new = selector.fit_transform(dataf.values, targetf.values.ravel())
    outcome = selector.get_support(True)
    new_features = [] # The list of your K best features
    for ind in outcome:
        new_features.append(dataf.columns.values[ind])
    return pd.DataFrame(data_new, columns=new_features)
