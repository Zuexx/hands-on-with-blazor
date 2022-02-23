module.exports = {
  mode: "jit",
  content: ["./**/*.html", "./**/*.razor"],
  theme: {
    extend: {
      width: {
        'px-40':'40px',
        'px-50': '50px',
        'px-60' : '60px',
        'px-80' : '80px',
        'px-300': '300px',
        'px-400': '400px',
        'calc-80':'calc(100vw - 80px)',
        'calc-300': 'calc(100vw - 300px)'        
        // 'full-2x':'200%'
      },
      minWidth: {        
        'px-60':'60px'
      },
      height: {
        'px-40':'40px',
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
        'px-40': '40px',
        '%-50': '50%'
      },
      inset: {
        '-px-50': '-50px',
        'px-80': '80px',
        'px-300': '300px'
      },
      boxShadow: {
        'tr-curve': '35px 35px 0 10px #fff',
        'br-curve': '35px -35px 0 10px #fff'
      }      
    },
  },
  plugins: [],
};
