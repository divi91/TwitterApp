module.exports = {
    context: __dirname,
    entry: ['babel-polyfill', './index.js'],
    output: {
        path: __dirname + "/dist",
        filename: "bundle.js"
    },
    watch: true,
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [
                            "@babel/preset-env",
                            "@babel/preset-react"
                        ],
                        "plugins": [
                            [
                                "@babel/plugin-proposal-class-properties"
                            ]
                        ]
                    }
                }
            },
            {
                test: /\.css$/,
                loader:'style-loader!css-loader'
            }
        ]
    }
}