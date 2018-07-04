import numpy as np
from sklearn.metrics import classification_report, confusion_matrix
from sklearn.metrics import accuracy_score
from sklearn import metrics

def show_results(y_test, y_pred, name):   
    print(name)
    print(accuracy_score(y_test, y_pred))
    conmat = np.array(confusion_matrix(y_test, y_pred, labels=[0.,1.]))
    print("----------------------------------")
    print("Accuracy Score: {0:.2f}%".format(accuracy_score(y_test, y_pred)*100))
    print("Confusion Matrix")
    print(conmat)
    print("Classification Report")
    print(classification_report(y_test, y_pred, labels=[0.,1.]))
    print("----------------------------------")

def write_results(y_test, y_pred, name, time, filename):
    tn, fp, fn, tp = confusion_matrix(y_test, y_pred).ravel()
    pre1 = metrics.precision_score(y_test, y_pred, pos_label=1., labels=[0.,1.])
    rec1 = metrics.recall_score(y_test, y_pred, pos_label=1., labels=[0.,1.])
    f11 = metrics.f1_score(y_test, y_pred, pos_label=1., labels=[0.,1.]) 
    pre2 = metrics.precision_score(y_test, y_pred, pos_label=0., labels=[0.,1.])
    rec2 = metrics.recall_score(y_test, y_pred, pos_label=0., labels=[0.,1.])
    f12 = metrics.f1_score(y_test, y_pred, pos_label=0., labels=[0.,1.]) 
    pre3 = metrics.precision_score(y_test, y_pred, average='weighted')
    rec3 = metrics.recall_score(y_test, y_pred, average='weighted')
    f13 = metrics.f1_score(y_test, y_pred, average='weighted') 
    acc = metrics.accuracy_score(y_test, y_pred)
    kappa = metrics.cohen_kappa_score(y_test, y_pred)
    spt = metrics.precision_recall_fscore_support(y_test, y_pred, labels=[0.,1.])[3]
    f= open(filename,"a+")
    f.write(name + ',' + str(tn) + ',' + str(fp) + ',' + str(fn) + ',' + str(tp) + ',' 
            + str(acc) + ',' + str(kappa) + ','
            + str(pre1) + ',' + str(rec1) + ',' + str(f11) + ','
            + str(pre2) + ',' + str(rec2) + ',' + str(f12) + ','
            + str(pre3) + ',' + str(rec3) + ',' + str(f13) + ',' + str(time) + ',' + ','.join([str(s) for s in spt]) + '\n')
    f.close()
    print('f-measure: ' + str(f11))
    print('accuracy:' + str(acc))


def write_features(name, features):
    f= open("features.txt","a+")
    f.write(name + ',' + features + '\n')
    f.close()