const FixStyleOnlyEntriesPlugin = require("webpack-fix-style-only-entries");

const path = require("path");

const fs = require('fs');

const is_scss = (file) => { 
  return file.slice((file.lastIndexOf(".") - 1 >>> 0) + 2) === 'scss';
}

const mode = process.env.NODE_ENV || "development";

const processEntryInfo = (folder) => {          
  var resolvedResults = [];
  var arrayOfFiles = fs.readdirSync(folder);

  arrayOfFiles.forEach(file => {
    if (is_scss(file)) {      
      resolvedResults.push(
        Object.assign({}, config, {
          name: file.split('.').slice(0, -1).join('.'),
          entry: [path.resolve(__dirname, folder, file)],
          output: { path:  path.resolve(__dirname, folder) },
        })
      );
    }
  });
  return resolvedResults;
}

const generateConfigs = (pathOfArray) => {
  var entryObjectAssignConfigs = [];
  
  pathOfArray.forEach(function (value) {    
    var resolvedResults = processEntryInfo(value);    

    entryObjectAssignConfigs = entryObjectAssignConfigs.concat(resolvedResults);
  });  

  return entryObjectAssignConfigs;
};

var config = {
  mode: mode,
  devtool: "source-map",
  output: {
    clean: true,
  },
  module: {
    rules: [
      {
        test: /\.(s[ac]|c)ss$/i,
        exclude: /node_modules/,
        use: [
          {
            loader: "file-loader",
            options: { name: "[name].css" },
          },
          "sass-loader",
          "postcss-loader",
        ],
      },
    ],
  },
  plugins: [new FixStyleOnlyEntriesPlugin()],
};

// Define the related path info which need to be pre-processed.
const PATH_INFO =
  [
    "./Client/wwwroot/css",
    "./Client/Components",
    "./Client/Shared"
  ];

module.exports = [generateConfigs(PATH_INFO)];
