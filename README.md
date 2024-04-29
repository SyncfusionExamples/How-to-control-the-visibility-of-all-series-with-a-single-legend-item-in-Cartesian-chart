# How-to-control-the-visibility-of-all-series-with-a-single-legend-item-in-Cartesian-chart
This article in the Syncfusion Knowledge Base explains how to control the visibility of all series with a single legend item in Cartesian chart

This article will explain the step to control the visibility of all series with a single legend item in a [Cartesian chart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts).

**Step 1:** Initialize the [ChartLegend](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartLegend.html) and set the [ToggleSeriesVisibility](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartLegend.html#Syncfusion_Maui_Charts_ChartLegend_ToggleSeriesVisibility) as true to control the series visibility.

**[XAML]**
```
<chart:SfCartesianChart.Legend>
    <chart:ChartLegend ToggleSeriesVisibility="True"/>
</chart:SfCartesianChart.Legend>
```
**Step 2:** Enable the legend for the first series by setting the [IsVisibleOnLegend](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_IsVisibleOnLegend) to `"True"` and `"False"` for the remaining series.

**[XAML]**
```
<chart:SfCartesianChart>
. . .
    <chart:LineSeries x:Name="series1" ItemsSource="{Binding Data1}" 
                      IsVisibleOnLegend="True"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series1"/>

    <chart:LineSeries ItemsSource="{Binding Data2}"
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series2"/>

    <chart:LineSeries ItemsSource="{Binding Data3}" 
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue" 
                      Label="Series3"/>
    
</chart:SfCartesianChart>
```
**Step 3:** Control the series visibility by using the following solutions:

**Solution 1 :**
Binding the [IsVisible](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_IsVisible) property of first series, to the rest of the series as shown in the following code sample.

**[XAML]**
```
<chart:SfCartesianChart>
. . .
    <chart:LineSeries x:Name="series1" ItemsSource="{Binding Data1}" 
                      IsVisibleOnLegend="True"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series1"/>

    <chart:LineSeries ItemsSource="{Binding Data2}"
                      IsVisible="{Binding Path=IsVisible, Source={x:Reference series1}}"
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series2"/>

    <chart:LineSeries ItemsSource="{Binding Data3}" 
                      IsVisible="{Binding Path=IsVisible, Source={x:Reference series1}}"
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue" 
                      Label="Series3"/>
                      
</chart:SfCartesianChart>
```
**Solution 2 :**
Without binding, you can also control all the series visibility by binding the same Boolean property (the property that holds the state of series visibility) from the view model to all the associated series [IsVisible](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_IsVisible) property. In this way, when the primary series legend is clicked, all the associated series visibility also collapsed. The following code sample shows how to toggle multiple series with a single legend item.

**[XAML]**
```
<chart:SfCartesianChart>
. . .
    <chart:LineSeries x:Name="series1" 
                      ItemsSource="{Binding Data1}" 
                      IsVisible="{Binding IsSeriesVisible, Mode=TwoWay}"
                      IsVisibleOnLegend="True"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series1"/>

    <chart:LineSeries ItemsSource="{Binding Data2}"
                      IsVisible="{Binding IsSeriesVisible}"
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue"
                      Label="Series2"/>

    <chart:LineSeries ItemsSource="{Binding Data3}" 
                      IsVisible="{Binding IsSeriesVisible}"
                      IsVisibleOnLegend="False"
                      XBindingPath="XValue" 
                      YBindingPath="YValue" 
                      Label="Series3"/>
                      
</chart:SfCartesianChart>
```
**[C#]**
```
public class ViewModel : INotifyPropertyChanged
{
    . . .
    private bool isSeriesVisible = true;

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsSeriesVisible
    {
        get { return isSeriesVisible; }
        set
        {
            isSeriesVisible = value;
            OnPropertyChanged(nameof(IsSeriesVisible));
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    . . .
}
```
**Output**
 ![Control_the_visibility_of_all_series_with_a_single_legend.gif](https://support.syncfusion.com/kb/agent/attachment/article/15893/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIxODU2Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.Fa1szVMVNt1nRJsy7ilzZM_YS3jtIdmDRyoUK79pzzg)