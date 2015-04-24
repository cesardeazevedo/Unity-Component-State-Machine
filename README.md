# Unity-Component-State-Machine

A Simple Unity State Machine designed with components


#How to use

1. Declare the initial states, and initialize them.

```c#
///<summary>
///Player.cs
///</summary>
public class Player : GameStateMachine<Player>
{
  /// <summary>
  /// Make sure that the name of these states are the same name of the script component
  /// </summary>
  public enum States {
    State1,
    State2,
    State3
  }

  void Awake() {
      base.Initialize<States>();
  }
  
  void Start() {
      ChangeState(State.State2);
  }
}
```

##Components

Each state, is an individual component, and have to be attached to the same GameObject (for now), and they are optional

```c#
/// <summary>
/// State1.cs
/// </summary>
public class State1 : StateComponentBase<Player>
{

  public override void Awake()
  {
      base.Awake();
  }
  
  public override void EnterState() { }
  
  public override void ExitState()  { }
  
}
```

##Properties

####Behaviour
The base component reference.

####NextState
Enum which represent the next state will come, only in the event `ExitState()`.

####IsActive
A bool which represent whether the current state is active or not.

```c#
//State1.cs
void Update() {
  if(IsActive) {
  //The State1 is active
  }
}
```

##Events

####EnterState()

- Emitted whenever `ChangeState()` is invoked to current state.

####ExitState()

- Emitted whenever `ChangeState()` is invoked to other state.

##Change States

You can change the states easily

* From Base Behaviour

```c#
//Player.cs
public void Start() {
  base.ChangeState(States.State2)
}
```

* From Components

```c#
//State2.cs
public void Start() {
    Behaviour.ChangeState(Player.States.State3);
}
```

#Contributing
1. Fork it!
2. Create your feature branch: git checkout -b my-new-feature
3. Commit your changes: git commit -m 'Add some feature'
4. Push to the branch: git push origin my-new-feature
5. Submit a pull request :D

#License
[MIT](./LICENSE)
