import React from 'react'
import Navigation from './Nav/Navigation'

function HomeWork() {
  return (
    <>
    <div style={{ display: 'flex', alignItems: 'center' }}>
      <div style={{ flexShrink: 0, position: 'absolute', left: 0 }}>
        <Navigation />
      </div>
      <div style={{ fontSize: '36px' }}>Home Work</div>
    </div>
  </>
  )
}

export default HomeWork