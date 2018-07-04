from data_processing import *

#Feature Selection
#1. Removing features with low variance
from sklearn.feature_selection import VarianceThreshold
def variance_threshold_selector(data, threshold=0.5):
    selector = VarianceThreshold(threshold)
    selector.fit(data.values)
    return data[data.columns[selector.get_support(indices=True)]]