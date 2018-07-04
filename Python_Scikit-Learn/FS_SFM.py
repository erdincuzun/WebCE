#4. Feature selection using SelectFromModel
from sklearn.svm import LinearSVC
from sklearn.feature_selection import SelectFromModel
import pandas as pd

#L1-based feature selection
def SelectFromModel_l1(dataf, targetf):
    lsvc = LinearSVC(C=0.01, penalty="l1", dual=False).fit(dataf, targetf.values.ravel())
    f= open("l1.txt","a+")
    f.write(",".join([str(c) for c in lsvc.coef_[0]]) + '\n')
    f.close()
    model = SelectFromModel(lsvc, prefit=True)
    data_new = model.transform(dataf)
    #feature names
    feature_idx = model.get_support()
    new_features = dataf.columns[feature_idx]
    return pd.DataFrame(data_new, columns=new_features)

from sklearn.ensemble import ExtraTreesClassifier
def SelectFromModel_treeBased(dataf, targetf):
    clf = ExtraTreesClassifier()
    clf = clf.fit(dataf, targetf.values.ravel())
    f= open("treebased.txt","a+")
    f.write(','.join([str(f) for f in clf.feature_importances_]) + '\n') 
    f.close()
    model = SelectFromModel(clf, prefit=True)
    data_new = model.transform(dataf)
    #feature names
    feature_idx = model.get_support()
    new_features = dataf.columns[feature_idx]
    return pd.DataFrame(data_new, columns=new_features)