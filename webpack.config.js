const FixStyleOnlyEntriesPlugin = require("webpack-fix-style-only-entries");

const path = require("path");

const mode = process.env.NODE_ENV || "development";

var getEntryInfo = (folder, file) => {
  if (file === "app")
    return {
      entry: __dirname + "/Client/" + folder + "/" + file + ".scss",
      output: path.resolve(__dirname, "Client/" + folder),
    };
  else
    return {
      entry: __dirname + "/Client/" + folder + "/" + file + ".razor.scss",
      output: path.resolve(__dirname, "Client/" + folder),
    };
};

var generateConfigs = (componetsOfMap) => {
  var entryObjectAssignConfigs = [];

  componetsOfMap.forEach(function (value, key) {
    var entryInfo = getEntryInfo(value, key);
    entryObjectAssignConfigs.push(
      Object.assign({}, config, {
        name: key,
        entry: [entryInfo.entry],
        output: { path: entryInfo.output },
      })
    );
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

// Define the mapping component name and folder name
const componentsArray = [
  ["app", "wwwroot/css"],
  ["Counter", "Pages"],
  ["FetchData", "Pages"],
  ["MainLayout", "Shared"],
  ["NavMenu", "Shared"],
];

module.exports = [generateConfigs(new Map(componentsArray))];
