using Castle.DynamicProxy;
using dynamicproxy_tutorial;

namespace dynamicproxy_tutorial.Test;
public class UnitTestSpec
{
    [Fact]
    public void IsFreezable_should_be_false_for_objects_created_with_ctor()
    {
        var nonFreezablePet = new Pet();
        Assert.False(Freezable.IsFreezable(nonFreezablePet));
    }

    [Fact]
    public void IsFreezable_should_be_true_for_objects_created_with_MakeFreezable()
    {
        var freezablePet = Freezable.MakeFreezable<Pet>();
        Assert.True(Freezable.IsFreezable(freezablePet));
    }

    [Fact]
    public void Freezable_should_work_normally()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        pet.Age = 3;
        pet.Deceased = true;
        pet.Name = "Rex";
        pet.Age += pet.Name.Length;
        Assert.NotNull(pet.ToString());
    }

    [Fact]
    public void Frozen_object_should_throw_ObjectFrozenException_when_trying_to_set_a_property()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        pet.Age = 3;

        Freezable.Freeze(pet);

        Assert.Throws<ObjectFrozenException>(() => pet.Name = "This should throw");
    }

    [Fact]
    public void Frozen_object_should_not_throw_when_trying_to_read_it()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        pet.Age = 3;

        Freezable.Freeze(pet);

        var age = pet.Age;
        var name = pet.Name;
        var deceased = pet.Deceased;
        var str = pet.ToString();
    }

    [Fact]
    public void Freeze_nonFreezable_object_should_throw_NotFreezableObjectException()
    {
        var rex = new Pet();
        Assert.Throws<NotFreezableObjectException>(() => Freezable.Freeze(rex));
    }
    [Fact]
    public void Freezable_should_not_intercept_normal_methods()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        var notUsed = pet.ToString(); //should not intercept
        var interceptedMethodsCount = GetInterceptedMethodsCountFor<FreezableInterceptor>(pet);
        Assert.Equal(0, interceptedMethodsCount);
    }

    [Fact]
    public void Freezable_should_intercept_property_setters()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        pet.Age = 5; //should intercept
        var interceptedMethodsCount = GetInterceptedMethodsCountFor<FreezableInterceptor>(pet);
        Assert.Equal(1, interceptedMethodsCount);
    }
    [Fact]
    public void DynProxyGetTarget_should_return_proxy_itself()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        var hack = pet as IProxyTargetAccessor;
        Assert.NotNull(hack);
        Assert.Same(pet, hack.DynProxyGetTarget());
    }
    [Fact]
    public void Freezable_should_not_hold_any_reference_to_created_objects()
    {
        // https://stackoverflow.com/a/70074940/1101691
        var pet = Freezable.MakeFreezable<Pet>();
        var petWeakReference = new WeakReference(pet, false);
        pet = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Assert.False(petWeakReference.IsAlive, "Object should have been collected");
    }
    private int GetInterceptedMethodsCountFor<TInterceptor>(object freezable)
        where TInterceptor: IHasCount
    {
        Assert.True(Freezable.IsFreezable(freezable));

        var hack = freezable as IProxyTargetAccessor;
        Assert.NotNull(hack);
        var loggingInterceptor = hack.GetInterceptors().
                                     Where(i => i is TInterceptor).
                                     Single();
        return ((IHasCount)loggingInterceptor!).Count;
    }
    [Fact]
    public void Freezable_should_log_getters_and_setters()
    {
        var pet = Freezable.MakeFreezable<Pet>();
        pet.Age = 4;
        var age = pet.Age;
        int logsCount = GetInterceptedMethodsCountFor<CallLoggingInterceptor>(pet);
        int freezeCount = GetInterceptedMethodsCountFor<FreezableInterceptor>(pet);
        Assert.Equal(2, logsCount);
        Assert.Equal(1, freezeCount);
    }

    [Fact]
    public void Freezable_should_not_intercept_methods()
    {

        var pet = Freezable.MakeFreezable<Pet>();
        pet.ToString();
        int logsCount = GetInterceptedMethodsCountFor<CallLoggingInterceptor>(pet);
        int freezeCount = GetInterceptedMethodsCountFor<FreezableInterceptor>(pet);

        // base implementation of ToString calls each property getter, that we intercept
        // so there will be 3 calls if method is not intercepter, otherwise 4.
        Assert.Equal(3, logsCount);
        Assert.Equal(0, freezeCount);
    }
}