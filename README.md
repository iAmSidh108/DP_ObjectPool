# **Object Pool Pattern in Unity:**

## **What is the Object Pool Pattern?**

The Object Pool Pattern is a design pattern that involves creating a pool of reusable objects to improve performance by avoiding the overhead of object instantiation and destruction. Instead of creating and destroying objects on demand, objects are recycled from the pool, enhancing efficiency in scenarios where object creation is resource-intensive.

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/54ca5d14-36e6-4436-a292-96926b1da38c)


## **Examples of using the Object Pool Pattern in game development:**

1. **Bullet Pool:**
   - **Objects:** Bullets fired by a weapon.
   - **Pooling:** Rather than instantiating and destroying bullets during gameplay, a pool of bullets is maintained, and inactive bullets are reused when needed.

2. **Particle System:**
   - **Objects:** Visual effects particles.
   - **Pooling:** Rather than constantly creating and destroying particles, a pool ensures that particles are reused, minimizing performance impact during frequent effects.

## **Drawbacks of using Object Pool Pattern:**

1. **Memory Usage:**
   - Object pools can consume additional memory since objects are kept in the pool, even if they are not in use.

2. **Complexity:**
   - Implementing and managing object pools can introduce complexity, especially in scenarios with diverse object types and dynamic usage patterns.

3. **Potential Overhead:**
   - In certain scenarios, the overhead of managing object pools might outweigh the benefits, especially for short-lived objects.

## **How to implement Object Pool Pattern:**

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/d2d2036c-215a-4fc0-853a-57c72cc989a3)

1. **Identify Reusable Objects:**
   - Determine which objects in your game can be reused to benefit from object pooling.

2. **Create Object Pool:**
   - Implement a pool manager responsible for creating, storing, and managing the pool of reusable objects.

3. **Initialize Objects:**
   - Initialize the objects in the pool during the game's startup to reduce instantiation overhead during gameplay.

4. **Acquire and Release Objects:**
   - Implement methods to acquire and release objects from the pool when needed, ensuring proper management of object states.

5. **Limit Pool Size:**
   - Consider implementing mechanisms to limit the size of the object pool to avoid excessive memory usage.

6. **Dynamic Pooling:**
   - Depending on the usage pattern, consider implementing dynamic pooling strategies, such as increasing or decreasing pool size based on demand.

7. **Use Unity's Object Pooling API:**
   - Unity provides Object Pooling APIs, such as the `ObjectPool` class, which can simplify the implementation of object pooling in Unity projects.

8. **Documentation:**
   - Clearly document the usage and management of the object pool to aid future maintenance and understanding.

Implementing the Object Pool Pattern in Unity is an effective way to optimize resource management, especially for frequently instantiated and short-lived objects, contributing to improved performance in resource-intensive scenarios.

## How I implemented Object Pool in the game.
I will use Gun Firing System to showcase how we can implement Pooling system. First I will show how we usually make Gun system. Simple way is to just instantiate gun prefab and destroy the prefab as per requirement. But the problem here is since we can instantiate as many prefab as possible, it is very resource heavy. This is how it is normally implemented without pooling method. 

This is a a bullet script that is attached to BulletPrefab which moves in particular direction at a certain speed when it is instantiated,

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/37ce2305-422c-4d85-8513-6c6d8b4cd51a)

This is a launcher script that is attached to Gun to instantiate the bulletPrefab.

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/a3a660ae-bed3-486e-b27d-0277ab2a4c80)

## Now this is how Object Pool is implemented.
Instead of instantiating and destroying the gameObhject again and again, We instantiate the prefab use it and then disable it. And whenever we require it we just enable it again and use it from the pool. This way we dont have to destroy and create things again and again and save a lot of resources.

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/9982733f-b81d-4494-8954-27c7780cdc3a)

![image](https://github.com/iAmSidh108/DP_ObjectPool/assets/63715240/36522bdc-a8ec-4674-831b-18f384f3f80e)

