module.exports = {
  mode: "jit",
  content: ["./**/*.html", "./**/*.razor"],
  theme: {
    extend: {
      width: {
        'px-50': '50px',
        'px-300': '300px',
        // 'full-2x':'200%'
      },
      minWidth: {
        'px-60':'60px'
      },
      height: {
        'px-50':'50px',
        'px-60':'60px'
      },
      lineHeight: {
        'px-60':'60px',
        'px-70':'70px'
      },
      borderWidth: {
        '10' : '10px'
      },
      transitionDuration: {
        '0.5' : '0.5s'
      },
      borderRadius: {
        'px-30': '30px',
        'p-1/2': '50%'
      },
      inset: {
        '-px-50': '-50px'
      },
      boxShadow: {
        'tr-curve': '35px 35px 0 10px #fff',
        'br-curve': '35px -35px 0 10px #fff'
      }      
    },
  },
  plugins: [],
};
