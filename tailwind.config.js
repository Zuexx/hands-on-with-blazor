const defaultTheme = require('tailwindcss/defaultTheme');

module.exports = {
  mode: 'jit',
  content: ['./**/*.html', './**/*.razor'],
  theme: {
    screens: {
      'xs': '480px',
      ...defaultTheme.screens
    },
    extend: {
      width: {
        'px-40': '40px',
        'px-50': '50px',
        'px-60': '60px',
        'px-80': '80px',
        'px-300': '300px',        
        'px-400': '400px',
        'calc-80': 'calc(100vw - 80px)',
        'calc-300': 'calc(100vw - 300px)',
        // 'full-2x':'200%'
      },
      minWidth: {
        'px-40': '40px',
        'px-60': '60px',
      },
      minHeight: {
        'px-500': '500px',
      },
      height: {
        'px-40': '40px',
        'px-50': '50px',
        'px-60': '60px',
      },
      lineHeight: {
        'px-60': '60px',
        'px-70': '70px',
      },
      borderWidth: {
        10: '10px',
      },
      transitionDuration: {
        0.5: '0.5s',
      },
      borderRadius: {
        'px-30': '30px',
        'px-40': '40px',
        '%-50': '50%',
      },
      inset: {
        '-px-50': '-50px',
        'px-80': '80px',
        'px-300': '300px',
        '-px-300': '-300px',
        'initial':'initial'
      },
      boxShadow: {
        'tr-curve': '35px 35px 0 10px #fff',
        'br-curve': '35px -35px 0 10px #fff',
        'card': '0 7px 25px rgba(0,0,0,0.08)',
      },
      gridTemplateColumns: {
        'single': 'repeat(1, 1fr)',
        'double': 'repeat(2, 1fr)',
        'triple': 'repeat(3, 1fr)',
        'quadruple':'repeat(4, 1fr)',
      },
      zIndex: {
        '10000': '10000',
        '10001':'10001'
      }
    }
  },
  plugins: [],
};
