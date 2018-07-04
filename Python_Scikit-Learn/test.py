from data_processing import *
from FS_Variance import *
from FS_Univariate import *
from FS_RFE import *
from FS_SFM import *
from test_clf import *
import pandas as pd
import arff
from sklearn.utils.class_weight import *

#score_func
from sklearn.feature_selection import chi2
from sklearn.feature_selection import f_classif

score_func = [chi2, f_classif]
score_funcStr = ['chi2', 'f_classif']

def test(dataf,targetf,name):
    write_features(name, ','.join(dataf.columns.values) + ',' + str(len(dataf.columns.values)))
    X_train, X_test, y_train, y_test = prepapare_train_test(dataf, targetf)
    start_classifiers_test(X_train, X_test, y_train.values.ravel(), y_test.values.ravel(), name)
    c, r = targetf.shape
    labels = targetf.values.reshape(c,)
    start_classifiers_cv_test(dataf, labels, name)

dataf, targetf = loadArff2()

#0.1
name = 'No Selection,0,0'
test(dataf, targetf, name)

#Univariate
for sfStr, sf in zip(score_funcStr, score_func):
    for number in range(1, 47, 5):
        data_new = SelectKBest_selector(dataf, targetf, number, sf)
        name = 'SelectKBest,' + sfStr + ',' + str(number)
        test(data_new,targetf,name)

for sfStr, sf in zip(score_funcStr, score_func):
    for number in range(10, 91, 10):
        data_new = SelectPercentile_selector(dataf, targetf, number, sf)
        name= 'SelectPercentile,' + sfStr + ',' + str(number)
        test(data_new, targetf, name)

for sfStr, sf in zip(score_funcStr, score_func):
    data_new = SelectFpr_selector(dataf, targetf, sf)
    name='SelectFpr,' + sfStr + ',alpha=0.05'
    test(data_new, targetf, name)

for sfStr, sf in zip(score_funcStr, score_func):
    data_new = SelectFdr_selector(dataf, targetf, sf)
    name='SelectFdr,' + sfStr + ',alpha=0.05'
    test(data_new, targetf, name)

for sfStr, sf in zip(score_funcStr, score_func):
    data_new = SelectFwe_selector(dataf, targetf, sf)
    name = 'SelectFwe,' + sfStr + ',alpha=0.05'
    test(data_new, targetf, name)

#Variance
for trs in [0.1, 0.5, 0.9]:
    data_new = variance_threshold_selector(dataf, trs)
    name = 'variance_threshold,' + str(trs) + ',0'
    test(data_new, targetf, name)

#RFE
data_new = SelectRFE_DT(dataf, targetf)
name='RFE,Decision Tree,0'
test(data_new, targetf, name)

data_new = SelectRFE_DTCV(dataf, targetf)
name='RFE,Decision Tree CV,0'
test(data_new, targetf, name)

#SelectFromModel
data_new = SelectFromModel_l1(dataf, targetf)
name='SelelectFromModel,l1,0'
test(data_new,targetf, name)

data_new = SelectFromModel_treeBased(dataf, targetf)
name='SelelectFromModel,treeBased,0'
test(data_new,targetf, name)
