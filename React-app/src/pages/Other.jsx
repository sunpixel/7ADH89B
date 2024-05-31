import React from 'react'
import Navigation from './Nav/Navigation'

function Other() {
  return (
    <>
    <div style={{ display: 'flex', alignItems: 'center' }}>
      <div style={{ flexShrink: 0, position: 'absolute', left: 0 }}>
        <Navigation />
      </div>
      <div style={{ fontSize: '36px' }}>Other</div>
    </div>
  </>
  )
}

export default Other