﻿function getChartColorsArray(a) {
    if (null !== document.getElementById(a)) {
        var r = document.getElementById(a).getAttribute("data-colors");
        if (r) return (r = JSON.parse(r)).map(function (a) {
            var r = a.replace(" ", "");
            if (-1 === r.indexOf(",")) {
                var t = getComputedStyle(document.documentElement).getPropertyValue(r);
                return t || r
            }
            var e = a.split(",");
            return 2 != e.length ? r : "rgba(" + getComputedStyle(document.documentElement).getPropertyValue(e[0]) + "," + e[1] + ")"
        })
    }
}
var linechartBasicColors = getChartColorsArray("line-chart");
linechartBasicColors && (options = {
    series: [{
        name: "series1",
        data: [31, 40, 36, 51, 49, 72, 69, 56, 68, 82, 68, 76]
    }],
    chart: {
        height: 320,
        type: "line",
        toolbar: "false",
        dropShadow: {
            enabled: !0,
            color: "#000",
            top: 18,
            left: 7,
            blur: 8,
            opacity: .2
        }
    },
    dataLabels: {
        enabled: !1
    },
    colors: linechartBasicColors,
    stroke: {
        curve: "smooth",
        width: 3
    }
}, (chart = new ApexCharts(document.querySelector("#line-chart"), options)).render());
var options, chart, donutchartColors = getChartColorsArray("donut-chart");
donutchartColors && (options = {
    series: [56, 38, 26],
    chart: {
        type: "donut",
        height: 262
    },
    labels: ["Series A", "Series B", "Series C"],
    colors: donutchartColors,
    legend: {
        show: !1
    },
    plotOptions: {
        pie: {
            donut: {
                size: "70%"
            }
        }
    }
}, (chart = new ApexCharts(document.querySelector("#donut-chart"), options)).render());
var radialoptions1, radialchart1, radialChartColors = getChartColorsArray("radialchart-1");
radialChartColors && (radialoptions1 = {
    series: [37],
    chart: {
        type: "radialBar",
        width: 60,
        height: 60,
        sparkline: {
            enabled: !0
        }
    },
    dataLabels: {
        enabled: !1
    },
    colors: radialChartColors,
    plotOptions: {
        radialBar: {
            hollow: {
                margin: 0,
                size: "60%"
            },
            track: {
                margin: 0
            },
            dataLabels: {
                show: !1
            }
        }
    }
}, (radialchart1 = new ApexCharts(document.querySelector("#radialchart-1"), radialoptions1)).render());
var radialoptions2, radialchart2, radialChart1Colors = getChartColorsArray("radialchart-2");
radialChart1Colors && (radialoptions2 = {
    series: [72],
    chart: {
        type: "radialBar",
        width: 60,
        height: 60,
        sparkline: {
            enabled: !0
        }
    },
    dataLabels: {
        enabled: !1
    },
    colors: radialChart1Colors,
    plotOptions: {
        radialBar: {
            hollow: {
                margin: 0,
                size: "60%"
            },
            track: {
                margin: 0
            },
            dataLabels: {
                show: !1
            }
        }
    }
}, (radialchart2 = new ApexCharts(document.querySelector("#radialchart-2"), radialoptions2)).render());
var radialoptions3, radialchart3, radialChart3Colors = getChartColorsArray("radialchart-3");
radialChart3Colors && (radialoptions3 = {
    series: [54],
    chart: {
        type: "radialBar",
        width: 60,
        height: 60,
        sparkline: {
            enabled: !0
        }
    },
    dataLabels: {
        enabled: !1
    },
    colors: ["#f46a6a"],
    plotOptions: {
        radialBar: {
            hollow: {
                margin: 0,
                size: "60%"
            },
            track: {
                margin: 0
            },
            dataLabels: {
                show: !1
            }
        }
    }
}, (radialchart3 = new ApexCharts(document.querySelector("#radialchart-3"), radialoptions3)).render());