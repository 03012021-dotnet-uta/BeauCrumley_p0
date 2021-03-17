//call function to run
SweetNSalty();

function SweetNSalty() {let maxCount = 1000;
    //list of vars to store state. lets function control program flow and keep track of results
    let itterCount = 0;
    let lineStr = "";
    let divisor1 = 3;
    let divisor2 = 5;
    let buzz1 = "sweetn'salty";
    let buzz2 = "sweet";
    let buzz3 = "salty";
    let buzz1Score = 0;
    let buzz2Score = 0;
    let buzz3Score = 0;

    //loop to run all of the main logic. 
    for (let i = 1; i <= maxCount; i++) {
        if (itterCount >= 9) {
            console.log(lineStr);
            itterCount = 0;
            lineStr = "";   
        }

        //set of if blocks to control flow. checks if conditions are met to replace a number with a buzz word. and which buzz word to substitute in
            //sweetn'salty is first checked, as it would never show otherwise if simpler checks passed first.
            //based on program path, updates appropriate variables and adds html to the page for a rendered visualization of what's going on.
                //html added has different classes assigned to enable styling results to give better visual representation of what's happening.
        if (i % divisor1 == 0 && i % divisor2 == 0) {
            document.getElementById('container1').innerHTML += `<div class="sweetSaltyBox"><div class="buzzbox-inner">SweetN'Salty!</div></div>`;
            lineStr += buzz1 + " ";
            buzz1Score++;
        } else if (i % divisor1 == 0) {
            document.getElementById('container1').innerHTML += `<div class="sweetBox"><div class="buzzbox-inner">Sweet!</div></div>`;
            lineStr += buzz2 + " ";
            buzz2Score++;
        } else if (i % divisor2 == 0) {
            document.getElementById('container1').innerHTML += `<div class="saltyBox"><div class="buzzbox-inner">Salty!</div></div>`;
            lineStr += buzz3 + " ";
            buzz3Score++;
        } else {
            document.getElementById('container1').innerHTML += `<div class="buzzbox"><div class="buzzbox-inner">${i}</div></div>`;
            lineStr += i + " ";
        }
        itterCount++
    }
    let scores = [buzz1Score, buzz2Score, buzz3Score];
    let words = [buzz1, buzz2, buzz3];
    printScores(words, scores);
    makeChart(words, scores);
}

//simple function for printing the scores of the 3 tracked items
function printScores(items, scores) {
    console.log(`\n${items[0]} --- shows up ${scores[0]}  times!`);
    console.log(`${items[1]} ---------- shows up ${scores[1]} times!`);
    console.log(`${items[2]} ---------- shows up ${scores[2]} times!`);
}

//Just flare. link to google charts included in head of html file.
function makeChart(buzz, scores) {
    google.charts.load('current', {'packages':['corechart']});

    //run drawChart when google API is loaded.
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        //create table from 2d array. first array sets what each 'column' is for.
            //in this case, for ever array following the first.
                //array[0] is what's being tracked
                //array[1] is how much it's occurred
                //array[2] is that dataset color
                //array[3] is saying what to show on each data set
            //each array represents new bar in bar graph.
        var data = google.visualization.arrayToDataTable([
            ['Occurrence', '# Times Occured', { role: 'style' }, { role: 'annotation' } ],
            [buzz[0], scores[0], '#119126', scores[0] ],
            [buzz[1], scores[1], '#3d596b', scores[1] ],
            [buzz[2], scores[2], '#3d6b54', scores[2] ]
        ]);
        //set up chart options. In this case they are mostly style overrides for defaults so that the chart fits with a dark theme
        var options = {
            'titlePosition': 'none',
            'width':document.getElementById('container1').getBoundingClientRect().width,//set chart width to width of sweetsalty display
            'height':300,
            'legend': { position: "none" },//don't need no legend
            'backgroundColor': '#1e1e1e',
            'chartArea': {
                'backgroundColor': {
                    'fill': '#1e1e1e'
                }
            },
            'hAxis': {//horizontal axis options
                'titleTextStyle': {
                    'color': "cacaca"
                },
                'textStyle': {
                    'color': '#cacaca'
                },
                'baselineColor': '#cacaca',
                'gridlines': {
                    'color': '#cacaca'
                }
            },
            'vAxis': {//vertical axis options
                'titleTextStyle': {
                    'color': "cacaca"
                },
                'textStyle': {
                    'color': '#cacaca'
                },
                'baselineColor': '#cacaca'
            }
        };

        //instantiates a chart object of choosing. BarChart in this case. Change to PieChart and watch the magic!
        var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}
